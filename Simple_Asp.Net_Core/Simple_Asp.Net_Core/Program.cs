using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Simple_Asp.Net_Core.Data;
using Simple_Asp.Net_Core.ServiceProvider;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddJWT();

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
app.UseCors("CorsTest");
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
app.Run();