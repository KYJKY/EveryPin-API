using EveryPinApi.Extensions;
using Service;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Logging;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.ConfigureCors();       // CORS
builder.Services.ConfigureRepositoryManager();      // RepositoryManager 추가
builder.Services.ConfigureServiceManager();         // ServiceManager 추가
builder.Services.ConfigureSqlContext(builder.Configuration);

// Presentation Layer에서 ControllerBase 상속 가능하도록
builder.Services.AddControllers()
                .AddApplicationPart(typeof(EveryPinApi.Presentation.AssemblyReference).Assembly);

// Swagger/OpenAPI 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
var app = builder.Build();

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


// auth
app.UseAuthentication();
app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();
app.Run();
