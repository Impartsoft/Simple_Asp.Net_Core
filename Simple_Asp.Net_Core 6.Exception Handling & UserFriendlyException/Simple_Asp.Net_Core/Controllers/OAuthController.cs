﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Simple_Asp.Net_Core.Dtos;
using Simple_Asp.Net_Core.Extensions;
using Simple_Asp.Net_Core.ServiceProvider;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Simple_Asp.Net_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Authenticate(string name, string password)
        {
            // 此处需补充用户校验与用户具体信息获取
            
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
            return Ok(new
            {
                access_token = tokenString
            });
        }
    }
}
