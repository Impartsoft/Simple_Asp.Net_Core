using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Simple_Asp.Net_Core.ServiceProviders
{
    public static class Swagger
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                //option.SwaggerDoc("v1", new OpenApiInfo
                //{
                //    Version = "0.0.1",
                //    Title = "Simple API",
                //    Description = "框架说明文档",
                //    TermsOfService = null,
                //    Contact = new OpenApiContact { Name = "Simple", Email = string.Empty, Url = null }
                //});

                //// 读取xml信息
                //var basePath = AppContext.BaseDirectory;
                //var xmlPath = Path.Combine(basePath, "Simple_Asp.Net_Core.xml");
                //option.IncludeXmlComments(xmlPath, true);

                // Add security definitions
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Please enter into field the word 'Bearer' followed by a space and the JWT value",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference()
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    }, Array.Empty<string>() }
                });
            });
        }
    }
}
