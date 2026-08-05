using AspNetCoreRateLimit;
using Entities.DataTranferObjcets;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Presentation.ActionFilters;
using Presentation.Controllers;
using Repository.Contracts;
using Repository.EF_Core;
using Services;
using Services.Contracts;

namespace WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, 
            IConfiguration configuration)=> services.AddDbContext<RepositoriesContex>
    (options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureServiceManager(this IServiceCollection services )=>
            services.AddScoped<IServiceManager,ServicesManager>();
        public static void ConfigureLoggerService(this IServiceCollection services)=>
            services.AddSingleton<ILoggerService, LoggerManager>();

        public static void ConfigureActionFilter(this IServiceCollection services)
        {
            services.AddScoped<ValidetionFilterAttribute>();
            services.AddSingleton<LogFilterAttribute>();
            services.AddScoped<ValidateMediaTypeAttribute>();
        }
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPlcy", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("X-Pagination")
                    );
            });
        }
        public static void ConfigureDataSahpper(this IServiceCollection services)
        {
            services.AddScoped<IDataShaper<BookDto>, DataShaper<BookDto>>();
        }
        public static void AddCustomMediaTypes(this IServiceCollection services)
        {
            services.Configure<MvcOptions>(config =>
            {
                
                var newtonsoftJsonOutputFormatter = config
                    .OutputFormatters
                    .OfType<NewtonsoftJsonOutputFormatter>()?.FirstOrDefault();

                if (newtonsoftJsonOutputFormatter != null)
                {
                    newtonsoftJsonOutputFormatter.SupportedMediaTypes
                    .Add("application/vnd.NiMu.hateoas+json");

                    newtonsoftJsonOutputFormatter.SupportedMediaTypes
                    .Add("aplication/vnd.NiMu.apiroot+json");
                }

                var xmlOutputFormatter = config
                    .OutputFormatters
                    .OfType<XmlDataContractSerializerOutputFormatter>()?.FirstOrDefault();

                if (xmlOutputFormatter is not null)
                {
                    xmlOutputFormatter.SupportedMediaTypes
                    .Add("application/vnd.NiMu.hateoas+xml");

                    xmlOutputFormatter.SupportedMediaTypes
                    .Add("aplication/vnd.NiMu.apiroot+xml");
                }
            });
        }

        public static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ApiVersionReader = new HeaderApiVersionReader("api-version");
                opt.Conventions.Controller<BooksController>()
                .HasDeprecatedApiVersion(new ApiVersion(1, 0));

                opt.Conventions.Controller<BooksV2Controller>()
               .HasDeprecatedApiVersion(new ApiVersion(2, 0));

            });
        }
        public static void ConfigureResponseCaching(this IServiceCollection services)
        {
            services.AddResponseCaching();
        }
        public static void ConfigureHttpCacheHeaders(this IServiceCollection services)
        {
            services.AddHttpCacheHeaders(exprationopt =>
            {
                exprationopt.MaxAge = 70;
                exprationopt.CacheLocation=CacheLocation.Private;
            },
            validationopt=>
            {
                validationopt.MustRevalidate = false;
            });
        }

        public static void ConfigureRateLimitingOptions(this IServiceCollection services)
        {
            var rateLimitRules = new List<RateLimitRule>()
            {
                new RateLimitRule()
                {
                    Endpoint="*",
                    Limit =3,
                    Period="1m"
                }
            };

            services.Configure<IpRateLimitOptions>(opt =>
            {
                opt.GeneralRules = rateLimitRules;
            });
            services.AddSingleton<IRateLimitCounterStore,MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitConfiguration,RateLimitConfiguration>();
            services.AddSingleton<IProcessingStrategy,AsyncKeyLockProcessingStrategy>();
        }
    }
}
