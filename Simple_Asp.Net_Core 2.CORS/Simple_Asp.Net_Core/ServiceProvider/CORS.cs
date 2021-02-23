using Microsoft.Extensions.DependencyInjection;

namespace Simple_Asp.Net_Core.ServiceProvider
{
    public static class CORS
    {
        public static void AddCORS(this IServiceCollection services)
        {
                services.AddCors(
                   options => options.AddPolicy(
                       "CorsTest",
                        // 目前先运行所有请求，当得知前端域名的时候，再改成WithOrigins方式
                        p => p.AllowAnyOrigin()
                             // 配置前端域名，注意端口号后不要带/斜杆
                             //p => p.WithOrigins("https://localhost:44372", "https://localhost:44372")
                             .AllowAnyHeader()
                             .AllowAnyMethod()
                             .WithExposedHeaders("Content-Disposition")));
        }
    }
}
