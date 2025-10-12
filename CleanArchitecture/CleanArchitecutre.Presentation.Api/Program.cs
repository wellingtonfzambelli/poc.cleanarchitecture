using CleanArchitecture.Application.DI;
using CleanArchitecture.Infrastructure.DI;
using CleanArchitecutre.Presentation.Api.DI;
using CleanArchitecutre.Presentation.Api.DI.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

string _path = builder.Environment.ContentRootPath;
IConfiguration _configuration = builder.Configuration;

builder.Services.AddPresentationServices(_configuration);
builder.Services.AddApplicationServices(_configuration);
builder.Services.AddInfrastructureServices(_configuration);

builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddClientConfiguration(_configuration);
builder.Services.AddRabbitConfiguration(_configuration);
//builder.Services.AddHealthCheckConfiguration(_configuration);
builder.Services.AddRateLimitConfiguration(_configuration);
builder.Services.AddCorsConfiguration(_configuration);
builder.AddSerilogConfiguration(_path, _configuration);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseCors(CORS_POLICY);
app.UseAuthorization();
//app.UseAuthentication();
app.MapControllers();
app.Run();