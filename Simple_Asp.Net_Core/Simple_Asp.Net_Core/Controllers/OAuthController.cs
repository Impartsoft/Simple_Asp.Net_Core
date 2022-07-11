using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Simple_Asp.Net_Core.Dtos;
using Simple_Asp.Net_Core.Extensions;
using Simple_Asp.Net_Core.ServiceProviders;
using System;
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
        public OAuthController(IConfiguration configuration, IOptionsSnapshot<Test2> optionsDelegate)
        {
            config = configuration.GetValue<string>("Test1");
            test2 = optionsDelegate.Value.Test21;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Authenticate(string name, string password)
        {

            //new ServiceProvider().GetService();


            // 此处需补充用户校验与用户具体信息获取
            if (string.IsNullOrWhiteSpace(name))
                throw new UserFriendlyException("用户名不能为空！");

            if (string.IsNullOrWhiteSpace(password))
                throw new UserFriendlyException("密码不能为空！");

            var user = new UserProviderDto(name, password);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Const.SecurityKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = Audiences.UpdateAudience(user.Name),
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

        public enum Role
        {
            None = 0,
            Salesperson = 1,
            GeneralManager = 2
        }
    }
}
