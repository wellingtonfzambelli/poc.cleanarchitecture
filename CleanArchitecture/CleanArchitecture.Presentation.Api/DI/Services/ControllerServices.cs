using CleanArchitecture.Presentation.Api.Filters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CleanArchitecture.Presentation.Api.DI.Services;

internal static class ControllerServices
{
    public static void AddControllerConfiguration(this IServiceCollection services)
    {
        services.AddControllers(config =>
        {
            config.Filters.Add(typeof(ExceptionFilter));
        })
        .AddJsonOptions
        (
            opts => opts.JsonSerializerOptions.Converters.Add
            (
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            )
        );
    }
}