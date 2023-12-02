using Microsoft.Extensions.Logging.AzureAppServices;

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

        public static void ConfigureLogger(this IServiceCollection services) =>
        services.Configure<AzureFileLoggerOptions>(options =>
        {
            // Azure Logging 관련 설정
            options.FileName = "logs-";
            options.FileSizeLimit = 50 * 1024;      // 파일 크기 제한
            options.RetainedFileCountLimit = 5;     // 최대 보존 파일 수
        });
    }
}
