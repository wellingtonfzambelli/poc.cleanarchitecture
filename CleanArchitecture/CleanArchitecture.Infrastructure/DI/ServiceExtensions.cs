using CleanArchitecture.Infrastructure.DI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CleanArchitecture.Infrastructure.DI;

public static class ServiceExtensions
{
    public static void AddInfrastructureServices
    (
        this IServiceCollection services,
        IConfiguration configuration,
        IHostBuilder hostBuilder,
        string path
    )
    {
        services.AddSqliteDatabase(configuration);
        services.AddRedisConfiguration(configuration);
        services.AddPersistenceServices(configuration);
        hostBuilder.AddSerilogConfiguration(path, configuration);
    }
}