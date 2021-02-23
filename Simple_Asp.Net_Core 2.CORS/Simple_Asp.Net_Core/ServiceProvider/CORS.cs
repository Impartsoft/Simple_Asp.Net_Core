using Microsoft.Extensions.DependencyInjection;

namespace Simple_Asp.Net_Core.ServiceProvider
{
    public static class CORS
    {
        public static void AddCORS(this IServiceCollection services)
        {
            //services.AddCors(
            //   options => options.AddPolicy(
            //       "CorsTest",
            //        // 配置前端域名，注意端口号后不要带/斜杆
            //        p => p.AllowAnyOrigin()
            //             //p => p.WithOrigins("https://localhost:44372", "https://localhost:44372")
            //             .AllowAnyHeader()
            //             .AllowAnyMethod()
            //             .WithExposedHeaders("Content-Disposition")));
        }
    }
}
