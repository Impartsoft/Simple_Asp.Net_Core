using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Asp.Net_Core.ServiceProviders
{
    public static class JWT
    {
        public static void AddJWT(this IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(o =>
           {
               o.RequireHttpsMetadata = false;
               o.Events = new JwtBearerEvents()
               {
                   OnAuthenticationFailed = context =>
                   {
                       //Token expired
                       if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                           context.Response.Headers.Add("Token-Expired", "true");

                       return Task.CompletedTask;
                   },
               };

               o.TokenValidationParameters = new TokenValidationParameters
               {
                   // 是否验证失效时间
                   ValidateLifetime = true,
                   ClockSkew = TimeSpan.FromSeconds(30),
                   ValidateAudience = true,
                   // 这里采用动态验证的方式，在重新登陆时，刷新token，旧token就强制失效了
                   AudienceValidator = AudienceValidator,
                   // 是否验证Issuer
                   ValidateIssuer = false,
                   // 是否验证SecurityKey
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Const.SecurityKey))
               };
           });
        }

        private static bool AudienceValidator(IEnumerable<string> audiences, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            return Audiences.IsNewestAudience(audiences.FirstOrDefault());
        }
    }
}
