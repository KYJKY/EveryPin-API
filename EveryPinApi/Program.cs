using EveryPinApi.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Logging.ApplicationInsights;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureCors();       // CORS


builder.Services.AddControllers();
// Swagger/OpenAPI 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Azure Logging
builder.Services.ConfigureLoggerBlob();
builder.Logging.AddAzureWebAppDiagnostics();




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

app.UseCors("CorsPolicy");

app.UseAuthorization();
app.MapControllers();
app.Run();
