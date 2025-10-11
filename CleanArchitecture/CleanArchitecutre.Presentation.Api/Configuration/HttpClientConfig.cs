using System.Net.Http.Headers;

namespace CleanArchitecutre.Presentation.Api.Configuration;

public static class HttpClientConfig
{
    public static void AddClientConfiguration(this IServiceCollection services, IConfiguration config)
    {
        var timeout = new TimeSpan(0, 0, 50);
        var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
        //var nasaBaseAddress = new Uri($"{config.ApiNasaAddress()}");

        //// My Api
        //services.AddHttpClient(NamedHttpClients.MYAPI_CLIENT).ConfigureHttpClient(x =>
        //{
        //    x.BaseAddress = nasaBaseAddress;
        //    x.DefaultRequestHeaders.Accept.Clear();
        //    x.DefaultRequestHeaders.Accept.Add(mediaType);
        //    x.Timeout = timeout;
        //});

        //services.AddScoped<INasaPortalClient>(p =>
        //    new NasaPortalClient(
        //        new BaseHttpClient(
        //            p.GetService<IHttpClientFactory>().CreateClient(NamedHttpClients.MYAPI_CLIENT),
        //            p.GetService<ILogger<BaseHttpClient>>()
        //        ),
        //        p.GetService<ILogger<NasaPortalClient>>(),
        //        config.ApiNasaApiKey())
        //    );
    }
}