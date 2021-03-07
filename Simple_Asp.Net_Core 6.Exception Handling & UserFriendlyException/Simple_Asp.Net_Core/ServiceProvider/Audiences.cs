using System;
using System.Collections.Generic;

namespace Simple_Asp.Net_Core.ServiceProvider
{
    public static class Audiences
    {
        private static IDictionary<string, string> _audiences = new Dictionary<string, string>();

        public static string UpdateAudience(string userNo)
        {
            if (string.IsNullOrWhiteSpace(userNo))
                return string.Empty;

            var audience = $"{userNo}_{DateTime.Now}";
            _audiences[userNo] = audience;

            return audience;
        }

        public static bool IsNewestAudience(string audience)
        {
            if (string.IsNullOrWhiteSpace(audience))
                return false;

            var userName = audience.Split('_')[0];

            if (!_audiences.ContainsKey(userName))
                return false;
            else
                return _audiences[userName] == audience;
        }
    }
}