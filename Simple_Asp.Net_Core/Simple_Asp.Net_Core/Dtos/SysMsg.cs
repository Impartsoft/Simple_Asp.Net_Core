namespace Simple_Asp.Net_Core.Dtos
{
    public class SysMsg
    {
        public static SysMsg Success(string message, object value = null) => new SysMsg(true, message, value);
        public static SysMsg Fail(string message, object value = null) => new SysMsg(false, message, value);
        private SysMsg(bool success, string message, object value)
        {
            IsSuccess = success;
            Message = message;
            Value = value;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Value { get; set; }
    }
}
