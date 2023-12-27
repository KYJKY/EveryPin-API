using EveryPinApi.Extensions;
using Microsoft.AspNetCore.HttpOverrides;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureCors();       // CORS
builder.Services.ConfigureRepositoryManager();      // RepositoryManager 추가
builder.Services.ConfigureServiceManager();         // ServiceManager 추가
builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.AddControllers()
                .AddApplicationPart(typeof(EveryPinApi.Presentation.AssemblyReference).Assembly);

// Swagger/OpenAPI 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Azure Logging
builder.Services.ConfigureLoggerFile();
builder.Services.ConfigureLoggerBlob();
builder.Logging.AddAzureWebAppDiagnostics();
// Auth
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

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
