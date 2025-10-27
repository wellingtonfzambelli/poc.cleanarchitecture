﻿using CleanArchitecutre.Presentation.Api.DI.Services;

namespace CleanArchitecutre.Presentation.Api.DI;

internal static class ServiceExtensions
{
    public static void AddPresentationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        services.AddSwaggerConfiguration();
        services.AddDependencyInjectionConfiguration();
        services.AddHealthCheckConfiguration(configuration);
        services.AddRateLimitConfiguration(configuration);
        services.AddCorsConfiguration(configuration);

        services.AddEndpointsApiExplorer();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}