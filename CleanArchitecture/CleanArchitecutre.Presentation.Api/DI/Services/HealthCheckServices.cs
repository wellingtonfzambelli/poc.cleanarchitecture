using CleanArchitecture.Infrastructure.Shared;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace CleanArchitecutre.Presentation.Api.DI.Services;

public static class HealthCheckServices
{
    public static void AddHealthCheckConfiguration(this IServiceCollection services, IConfiguration config)
    {
        services.AddHealthChecks()
            .AddSqlite(config.SqlLiteConnectionString())
            //.AddSqlServer(config.SqlServerConnectionString())
            .AddRedis(config.RedisConnectionString());
    }

    public static void AddHealthCheckApplication(this WebApplication app, IConfiguration config)
    {
        app.MapHealthChecks("health", new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse // format the health check response in a json format
        });
    }
}