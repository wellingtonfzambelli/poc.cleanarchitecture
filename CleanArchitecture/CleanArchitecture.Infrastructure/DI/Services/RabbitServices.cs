using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.DI.Services;

internal static class RabbitServices
{
    public static void AddRabbitConfiguration(this IServiceCollection services, IConfiguration config)
    {
        //services.AddScoped<ISetupMessageBroker>(p =>
        //new SetupMessageBroker(
        //    config.RabbitHostname(),
        //    config.RabbitVHost(),
        //    config.RabbitUsername(),
        //    config.RabbitPassord())
        //);
    }
}