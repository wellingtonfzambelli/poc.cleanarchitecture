using CleanArchitecutre.Presentation.Api.DI.Configuration;

namespace CleanArchitecutre.Presentation.Api.DI;

public static class ServiceExtensions
{
    public static void AddPresentationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        services.AddSwaggerConfiguration();
        services.AddDependencyInjectionConfiguration();
        //services.AddHealthCheckConfiguration(_configuration);
        services.AddRateLimitConfiguration(configuration);
        services.AddCorsConfiguration(configuration);

        services.AddEndpointsApiExplorer();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}