using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Simple_Asp.Net_Core.Data;
using Simple_Asp.Net_Core.ServiceProviders;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddJWT();

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
builder.Services.Configure<Test2>(builder.Configuration.GetSection("Test2"));

builder.Host.ConfigureLogging((loggingBuilder) => { loggingBuilder.ClearProviders(); loggingBuilder.AddConsole(); });

//builder.Services.AddDbContextFactory<ApplicationDbContext>(
//        options =>
//            options.UseNpgsql(@"Server=(localdb)\mssqllocaldb;Database=Test"));

builder.Services.AddDbContext<CommanderContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgereSql")));
builder.Services.AddDbContext<FTPFileContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgereSql")));

//builder.Services.AddDbContextPool<CommanderContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgereSql")));


builder.Services.AddCORS();
builder.Services.AddMvc();
builder.Services.AddSwagger();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICommanderRepo, SqlCommanderRepo>();
builder.Services.AddScoped<IFTPFileRepo, FTPFileRepo>();
//builder.Services.AddSingleton<IFTPFileRepo, FTPFileRepo>();

builder.Services.AddControllers().AddNewtonsoftJson(s =>
{
    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
});

app.UseExceptionHandler(builder => builder.Run(async context => await ExceptionHandler.ErrorEvent(context)));
app.UseRouting();
app.UseCors("CorsTest");
app.UseAuthentication();
app.UseAuthorization();

// custom mid1
app.Use(async (httpcontext, _next) =>
{
    global::System.Console.WriteLine("mid1 request");

    await _next.Invoke();

    global::System.Console.WriteLine("mid1 respose");
});

// custom mid2
app.Use(async (httpcontext, _next) =>
{
    global::System.Console.WriteLine("mid2 request");

    await _next.Invoke();

    global::System.Console.WriteLine("mid2 respose");
});



app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
app.Run();