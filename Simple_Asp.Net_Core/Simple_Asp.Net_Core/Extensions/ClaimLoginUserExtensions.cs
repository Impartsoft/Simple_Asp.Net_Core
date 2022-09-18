using Newtonsoft.Json;
using Simple_Asp.Net_Core.Dtos;
using Simple_Asp.Net_Core.ServiceProviders;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Simple_Asp.Net_Core.Extensions
{
    public static class ClaimLoginUserExtensions
    {
        private const string USER = "User";

        public static ClaimsIdentity GetClaimsIdentity(this UserReadDto user)
        {
            return new ClaimsIdentity(new Claim[]
            {
                new Claim(USER, JsonConvert.SerializeObject(user))
            });
        }

        public static Guid GetCurrentUserId(this ClaimsPrincipal principal)
        {
            var user = principal.GetLoggedInUser();

            return user.Id;
        }

        public static UserReadDto GetLoggedInUser(this ClaimsPrincipal principal)
        {
            if (principal == null || principal.Claims == null || principal.Claims.Count() == 0)
                throw new UserFriendlyException("用户未登入！");

            return principal.Claims.GetCurrentUser();
        }

        public static UserReadDto GetCurrentUser(this IEnumerable<Claim> claims)
        {
            return JsonConvert.DeserializeObject<UserReadDto>(claims.Get(USER));
        }

        public static string Get(this IEnumerable<Claim> claims, string claimType)
        {
            return claims.Where(v => v.Type == claimType).First().Value;
        }
    }
}
