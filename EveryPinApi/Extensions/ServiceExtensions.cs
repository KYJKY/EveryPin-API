using Entites.Models;
using Microsoft.AspNetCore.Identity;
using Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.AzureAppServices;
using Repository;
using Service.Contracts;
using Service;

namespace EveryPinApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            // Cors 관련 설정

            // 현재는 모든 도메인을 CORS 정책으로부터 허용함
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            // 특정 도메인만 허용하도록 수정
            //options.AddPolicy("CorsPolicy", builder =>
            //builder.WithOrigins("https://example.com")      // 입력한 도메인만 접근 가능
            //.WithMethods("POST", "GET")                     // POST, GET 방식만 접근 가능
            //.WithHeaders("accept", "content-type"));        // 특정 헤더만 허용

        });

        public static void ConfigureLoggerFile(this IServiceCollection services) =>
        services.Configure<AzureFileLoggerOptions>(options =>
        {
            // Azure Logging 파일시스템 관련 설정
            options.FileName = "logs-";
            options.FileSizeLimit = 50 * 1024;      // 파일 크기 제한
            options.RetainedFileCountLimit = 5;     // 최대 보존 파일 수
        });

        public static void ConfigureLoggerBlob(this IServiceCollection services) =>
        services.Configure<AzureBlobLoggerOptions>(options =>
        {
            // Azure Logging 블롭 관련 설정
            options.BlobName = "log.txt";
        });

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 10;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<RepositoryContext>()
            .AddDefaultTokenProviders();
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddSqlServer<RepositoryContext>(configuration.GetConnectionString("everypindb"));

    }
}
