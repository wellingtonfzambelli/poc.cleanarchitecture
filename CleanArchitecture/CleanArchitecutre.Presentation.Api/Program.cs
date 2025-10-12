using CleanArchitecture.Application.DI;
using CleanArchitecture.Infrastructure.DI;
using CleanArchitecutre.Presentation.Api.DI;
using CleanArchitecutre.Presentation.Api.DI.Services;

var builder = WebApplication.CreateBuilder(args);
IConfiguration _configuration = builder.Configuration;

builder.Services.AddPresentationServices(_configuration);
builder.Services.AddApplicationServices(_configuration);
builder.Services.AddInfrastructureServices(_configuration, builder.Host, builder.Environment.ContentRootPath);



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.AddHealthCheckApplication(_configuration);
//app.UseCors(CORS_POLICY);
app.UseAuthorization();
//app.UseAuthentication();
app.MapControllers();
app.Run();