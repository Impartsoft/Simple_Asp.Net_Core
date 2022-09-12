using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Simple_Asp.Net_Core.Data;
using Simple_Asp.Net_Core.Dtos;
using Simple_Asp.Net_Core.Extensions;
using Simple_Asp.Net_Core.Model.Models;
using Simple_Asp.Net_Core.ServiceProviders;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Simple_Asp.Net_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        string config;
        string test2;
        private readonly ILogger<OAuthController> _logger;
        private readonly IMapper _mapper;
        private readonly IUserRepo _userRepo;
        public OAuthController(IConfiguration configuration,
            IOptionsSnapshot<Test2> optionsDelegate,
            ILogger<OAuthController> logger,
            IMapper mapper,
            IUserRepo userRepo)
        {
            config = configuration.GetValue<string>("Test1");
            test2 = optionsDelegate.Value.Test21;
            _logger = logger;
            _mapper = mapper;
            _userRepo = userRepo;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Authenticate(string name, string password)
        {
            _logger.LogError("TEST1");

            // 此处需补充用户校验与用户具体信息获取
            if (string.IsNullOrWhiteSpace(name))
                throw new UserFriendlyException("用户名不能为空！");

            if (string.IsNullOrWhiteSpace(password))
                throw new UserFriendlyException("密码不能为空！");

            if (!VerifyUser(name, password, out UserReadDto user))
                throw new UserFriendlyException("用户验证失败！");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Const.SecurityKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = Audiences.UpdateAudience(user.UserName),
                Subject = user.GetClaimsIdentity(),
                Expires = DateTime.UtcNow.AddDays(0.5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            Role role = Role.Salesperson;
            if (name.ToUpper().Contains("MANAGER"))
                role = Role.GeneralManager;

            return Ok(SysMsg.Success("登入成功！", new { access_token = tokenString, role }));
        }

        /// <summary>
        /// 验证用户信息
        /// </summary>
        private bool VerifyUser(string name, string password, out UserReadDto userRead)
        {
            var user = _userRepo.GetUserByNameAndPassword(name, password);
            userRead = _mapper.Map<UserReadDto>(user);

            return userRead != null;
        }

        public IActionResult Register(UserCreateDto userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput.UserName))
                throw new UserFriendlyException("用户名不能为空！");

            if (string.IsNullOrWhiteSpace(userInput.Password))
                throw new UserFriendlyException("密码不能为空！");

            var dbUser = _userRepo.GetUserByUserName(userInput.UserName);
            if (dbUser != null)
                throw new UserFriendlyException("用户名已经存在！");

            var user = _mapper.Map<User>(userInput);
            _userRepo.CreateUser(user);

            return Ok(user);
        }

        public IActionResult VerifyUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new UserFriendlyException("用户名不能为空！");

            var dbUser = _userRepo.GetUserByUserName(userName);
            if (dbUser != null)
                throw new UserFriendlyException("用户名已经存在！");

            return Ok();
        }

        public IActionResult UpdateUser(UserUpdateDto userUpdateDto)
        {
            if (string.IsNullOrWhiteSpace(userUpdateDto.UserName))
                throw new UserFriendlyException("用户名不能为空！");

            if (string.IsNullOrWhiteSpace(userUpdateDto.Password))
                throw new UserFriendlyException("密码不能为空！");

            var dbUser = _userRepo.GetUserById(userUpdateDto.Id);
            _mapper.Map(userUpdateDto, dbUser);
            _userRepo.UpdateUser(dbUser);

            return Ok();
        }

        public enum Role
        {
            None = 0,
            Salesperson = 1,
            GeneralManager = 2
        }
    }
}
