using Newtonsoft.Json;

namespace Simple_Asp.Net_Core.Dtos
{
    public class SysMsg
    {
        public static SysMsg Success(object value) => new SysMsg(true, string.Empty, value);
        public static SysMsg Success(string message, object value = null) => new SysMsg(true, message, value);
        public static SysMsg Fail(string message, object value = null) => new SysMsg(false, message, value);
        private SysMsg(bool success, string message, object value)
        {
            IsSuccess = success;
            Message = message;
            Value = value;
        }

        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public object Value { get; set; }
    }
}
