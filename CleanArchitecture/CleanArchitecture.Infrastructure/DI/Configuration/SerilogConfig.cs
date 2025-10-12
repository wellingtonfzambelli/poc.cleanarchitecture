using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace CleanArchitecutre.Presentation.Api.DI.Configuration;

public static class SerilogConfig
{
    public static void AddSerilogConfiguration(this IHostBuilder hostBuilder, string path, IConfiguration config) =>
        hostBuilder.UseSerilog((context, configuration) =>
        configuration.ReadFrom.Configuration(context.Configuration)

            .MinimumLevel.Warning()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
            .MinimumLevel.Override("System", LogEventLevel.Error)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            //.WriteTo.File(
            //    path: $"{path}\\logs\\log.txt",
            //    rollingInterval: RollingInterval.Day,
            //    outputTemplate: "{Timestamp:HH:mm} [{Level}] ({ThreadId}) {Message}{NewLine}{Exception}")
            //.WriteTo.MySQL(config.ConnectionString(), "EventLog")
            );
}