using EveryPinApi.Extensions;
using Service;
using Microsoft.AspNetCore.HttpOverrides;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();       // CORS
builder.Services.ConfigureRepositoryManager();      // RepositoryManager �߰�
builder.Services.ConfigureServiceManager();         // ServiceManager �߰�
builder.Services.ConfigureSqlContext(builder.Configuration);

// Presentation Layer���� ControllerBase ��� �����ϵ���
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
builder.Services.ConfigureJWT(builder.Configuration);

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));



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
