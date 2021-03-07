using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Simple_Asp.Net_Core.Dtos
{
    public class UserProviderDto
    {
        public UserProviderDto(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public string ID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Mail { get; set; }

        public string Password { get; set; }
    }
}
