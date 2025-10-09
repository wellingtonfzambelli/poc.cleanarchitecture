using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Infrastructure.Configuration;

public static class GlobalParams
{
    // SQL SERVER
    public static string ConnectionString(this IConfiguration configuration) =>
        configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Connection string 'DefaultConnection' not found.");

    // Redis
    public static string RedisServer(this IConfiguration configuration) =>
        configuration.GetValue<string>("RedisConnection") ?? throw new NullReferenceException();

    // Cors
    public static string CorsName(this IConfiguration configuration) =>
        "CorsName";
}