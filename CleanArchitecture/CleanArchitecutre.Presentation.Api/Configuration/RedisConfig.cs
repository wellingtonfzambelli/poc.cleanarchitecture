using CleanArchitecture.Infrastructure.Configuration;
using Redis.OM;

namespace CleanArchitecutre.Presentation.Api.Configuration;

public static class RedisConfig
{
    public static void AddRedisConfiguration(this IServiceCollection services, IConfiguration config)
    {
        var provider = new RedisConnectionProvider(config.RedisConnectionString());
        services.AddSingleton(provider);
    }
}