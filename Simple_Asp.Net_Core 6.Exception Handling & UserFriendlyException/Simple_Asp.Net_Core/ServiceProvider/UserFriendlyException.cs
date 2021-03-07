using System;

namespace Simple_Asp.Net_Core.ServiceProvider
{
    public class UserFriendlyException : Exception
    {
        public UserFriendlyException(string message) : base(message)
        {
        }

        public UserFriendlyException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
