using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Infrastructure.Configuration;

public static class GlobalParams
{
    // MySQL
    public static string ConnectionString(this IConfiguration configuration) =>
        configuration.GetValue<string>("CONNECTIONSTRING") ?? throw new NullReferenceException();

    // Redis
    public static string RedisServer(this IConfiguration configuration) =>
        configuration.GetValue<string>("REDIS_SERVER") ?? throw new NullReferenceException();

    // Cors
    public static string CorsName(this IConfiguration configuration) =>
        "corsapp";

    // Rate Limit
    public static int RateLimit(this IConfiguration configuration) =>
        configuration.GetValue<int?>("RATE_LIMIT") ?? throw new NullReferenceException();
    public static int RateLimitSeconds(this IConfiguration configuration) =>
        configuration.GetValue<int?>("RATE_LIMIT_SECONDS") ?? throw new NullReferenceException();
    public static int RateLimitQueueLimit(this IConfiguration configuration) =>
        configuration.GetValue<int?>("RATE_LIMIT_QUEUE_LIMIT") ?? throw new NullReferenceException();
}