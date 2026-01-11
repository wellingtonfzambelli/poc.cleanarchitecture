using CleanArchitecture.Presentation.Api.DI.Services;

namespace CleanArchitecture.Presentation.Api.DI;

internal static class ServiceExtensions
{
    public static void AddPresentationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        services.AddSwaggerConfiguration();
        services.AddDependencyInjectionConfiguration();
        services.AddMediatorService();
        services.AddHealthCheckConfiguration(configuration);
        services.AddRateLimitConfiguration(configuration);
        services.AddCorsConfiguration(configuration);

        services.AddEndpointsApiExplorer();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}