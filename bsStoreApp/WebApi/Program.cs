using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using Presentation.ActionFilters;
using Repository.EF_Core;
using Services;
using Services.Contracts;
using WebApi.Extensions;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
LogManager.Setup().LoadConfigurationFromFile(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
    config.CacheProfiles.Add("5mins", new CacheProfile() { Duration = 300 });
})
    .AddCustomCsvFormatter()
    .AddXmlDataContractSerializerFormatters()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly)
    .AddNewtonsoftJson();

builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureActionFilter();
builder.Services.ConfigureCors();
builder.Services.ConfigureDataSahpper();
builder.Services.AddCustomMediaTypes();
builder.Services.AddScoped<IBookLinks,BookLinks>();
builder.Services.ConfigureVersioning();
builder.Services.ConfigureResponseCaching();
builder.Services.ConfigureHttpCacheHeaders();
builder.Services.AddMemoryCache();
builder.Services.ConfigureRateLimitingOptions();
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);

var app = builder.Build();

var logger=app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseIpRateLimiting();
app.UseCors("CorsPlay");
app.UseResponseCaching();
app.UseHttpCacheHeaders();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
