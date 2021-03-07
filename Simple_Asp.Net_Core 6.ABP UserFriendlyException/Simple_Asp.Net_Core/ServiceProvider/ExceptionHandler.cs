using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Asp.Net_Core.ServiceProvider
{
    public class ExceptionHandler
    {
        public static Task ErrorEvent(HttpContext context)
        {
            var feature = context.Features.Get<IExceptionHandlerFeature>();
            var error = feature?.Error;

            if (error.GetType() == typeof(UserFriendlyException))
            {
                SetResponse(context);
                var content = GetApiResponse(error.Message);

                return context.Response.WriteAsync(JsonConvert.SerializeObject(content), Encoding.UTF8);
            }
            else
            {
                // 写入日志
                // error.Message
                // error.StackTrace

                SetResponse(context);
                var content = GetApiResponse("程序发生错误，请联系客服！");
                return context.Response.WriteAsync(JsonConvert.SerializeObject(content), Encoding.UTF8);
            }
        }

        /// <summary>
        /// 解决异常消息返回跨域问题
        /// </summary>
        private static void SetResponse(HttpContext context)
        {
            context.Response.Clear();
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            context.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET");
            context.Response.ContentType = "application/json";
        }

        /// <summary>
        /// 响应Response
        /// </summary>
        private static ErrorResponse GetApiResponse(string message)
        {
            return new ErrorResponse() { success = false, message = message };
        }

        private class ErrorResponse
        {
            public bool success { get; set; }
            public bool Success { get { return success; } }
            public string message { get; set; }
            public string Message { get { return message; } }
        }
    }
}