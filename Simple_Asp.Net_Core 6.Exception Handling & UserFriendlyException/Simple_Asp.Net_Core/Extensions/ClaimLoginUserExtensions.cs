using Newtonsoft.Json;
using Simple_Asp.Net_Core.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Simple_Asp.Net_Core.Extensions
{
    public static class ClaimLoginUserExtensions
    {
        private const string USER = "User";

        public static ClaimsIdentity GetClaimsIdentity(this UserProviderDto user)
        {
            return new ClaimsIdentity(new Claim[]
            {
                new Claim(USER, JsonConvert.SerializeObject(user))
            });
        }

        public static UserProviderDto GetLoginUser(this IEnumerable<Claim> claims)
        {
            var user = JsonConvert.DeserializeObject<UserProviderDto>(claims.Get(USER));

            return user;
        }

        public static string Get(this IEnumerable<Claim> claims, string claimType)
        {
            return claims.Where(v => v.Type == claimType).First().Value;
        }
    }
}
