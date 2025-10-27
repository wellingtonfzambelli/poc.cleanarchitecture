using CleanArchitecture.Infrastructure.Shared;

namespace CleanArchitecutre.Presentation.Api.DI.Services;

internal static class CorsServices
{
    public static void AddCorsConfiguration(this IServiceCollection services, IConfiguration config)
    {
        services.AddCors(p => p.AddPolicy(config.CorsName(), builder =>
        {
            builder.WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader();
        }));
    }
}