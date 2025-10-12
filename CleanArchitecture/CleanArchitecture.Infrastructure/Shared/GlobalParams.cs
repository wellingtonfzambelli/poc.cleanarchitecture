using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Infrastructure.Shared;

public static class GlobalParams
{
    // SQL SERVER
    public static string SqlServerConnectionString(this IConfiguration configuration) =>
        configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Connection string 'DefaultConnection' not found.");

    // SQLITE
    public static string SqlLiteConnectionString(this IConfiguration configuration) =>
        configuration.GetConnectionString("SqliteConnection") ?? throw new NullReferenceException("Connection string 'SqliteConnection' not found.");

    // Redis
    public static string RedisConnectionString(this IConfiguration configuration) =>
        configuration.GetValue<string>("RedisConnection") ?? throw new NullReferenceException("Connection string 'RedisConnection' not found.");

    #region Security

    // Cors
    public static string CorsName(this IConfiguration configuration) =>
        "CorsName";

    // Rate Limit
    public static int RateLimitMaximunRequest(this IConfiguration configuration) =>
        configuration.GetValue<int>("MaximunRequest:PermitLimit", 100);

    public static int RateLimitQueueLimit(this IConfiguration configuration) =>
        configuration.GetValue<int>("MaximunRequest:QueueLimit", 100);

    public static int RateLimitSeconds(this IConfiguration configuration) =>
        configuration.GetValue<int>("MaximunRequest:Seconds", 100);

    #endregion Security
}