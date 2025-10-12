using CleanArchitecture.Infrastructure.DI.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.DI;

public static class ServiceExtensions
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSqliteDatabase(configuration);        
        services.AddRedisConfiguration(configuration);
        services.AddPersistenceServices(configuration);
    }
}