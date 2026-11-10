using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Google.Meet.HttpClients.Registrars;
using Soenneker.Google.Meet.OpenApiClientUtil.Abstract;

namespace Soenneker.Google.Meet.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class GoogleMeetOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="GoogleMeetOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddGoogleMeetOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddGoogleMeetOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IGoogleMeetOpenApiClientUtil, GoogleMeetOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="GoogleMeetOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddGoogleMeetOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddGoogleMeetOpenApiHttpClientAsSingleton()
                .TryAddScoped<IGoogleMeetOpenApiClientUtil, GoogleMeetOpenApiClientUtil>();

        return services;
    }
}
