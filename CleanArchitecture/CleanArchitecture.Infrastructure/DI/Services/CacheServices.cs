using CleanArchitecture.Infrastructure.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Redis.OM;

namespace CleanArchitecture.Infrastructure.DI.Services;

public static class CacheServices
{
    public static void AddRedisConfiguration(this IServiceCollection services, IConfiguration config)
    {
        var provider = new RedisConnectionProvider(config.RedisConnectionString());
        services.AddSingleton(provider);
    }
}