using CleanArchitecture.Infrastructure.Shared;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;

namespace CleanArchitecture.Presentation.Api.DI.Services;

internal static class HealthCheckServices
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
            ResponseWriter = WriteResponseFormatted // format the health check response in a json format
        });
    }

    private static Task WriteResponseFormatted(HttpContext context, HealthReport report)
    {
        context.Response.ContentType = "application/json";

        var json = JsonSerializer.Serialize(
            new
            {
                status = report.Status.ToString(),
                totalDuration = report.TotalDuration,
                entries = report.Entries.Select(e => new
                {
                    name = e.Key,
                    status = e.Value.Status.ToString(),
                    duration = e.Value.Duration,
                    description = e.Value.Description
                })
            },
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        return context.Response.WriteAsync(json);
    }
}