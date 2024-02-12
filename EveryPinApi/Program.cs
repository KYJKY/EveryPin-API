using EveryPinApi.Extensions;
using Service;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.ConfigureCors();       // CORS
    builder.Services.ConfigureRepositoryManager();      // RepositoryManager 추가
    builder.Services.ConfigureServiceManager();         // ServiceManager 추가
    builder.Services.ConfigureSqlContext(builder.Configuration);

    
    builder.Services.AddControllers(config => {
        config.RespectBrowserAcceptHeader = true;   // AcceptHeader를 읽도록 허용
    }).AddXmlDataContractSerializerFormatters()     // XML형식을 지원하도록 허용
        .AddApplicationPart(typeof(EveryPinApi.Presentation.AssemblyReference).Assembly);   // Presentation Layer에서 ControllerBase 상속 가능하도록

    // Swagger/OpenAPI 
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(option =>
    {
        option.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = JwtBearerDefaults.AuthenticationScheme,
        });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme
                    }
                },
                new string[]{}
            }
        });
    });

    // Azure Logging
    builder.Logging.AddAzureWebAppDiagnostics();
    builder.Services.ConfigureLoggerFile();
    builder.Services.ConfigureLoggerBlob();

    // Auth
    builder.Services.AddAuthentication();
    builder.Services.ConfigureIdentity();
    builder.Services.ConfigureJWT(builder.Configuration);

    // AutoMapper
    builder.Services.AddAutoMapper(typeof(Program));
}

var app = builder.Build();
{
    app.ConfigureExceptionHandler(app.Logger);

    // Configure the HTTP request pipeline.
    //if (app.Environment.IsDevelopment())
    //{
    //    app.UseDeveloperExceptionPage();
    //}

    // Swagger
    app.UseSwagger();
    app.UseSwaggerUI();


    app.UseStaticFiles();
    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.All
    });

    //app.UseDeveloperExceptionPage(); // 디버깅용도. 활성화 시, 글로벌 로깅으로 진입 X

    // auth
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseCors("CorsPolicy");

    app.MapControllers();
}

app.Run();
