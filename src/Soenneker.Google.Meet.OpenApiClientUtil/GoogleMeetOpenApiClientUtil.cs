using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Google.Meet.HttpClients.Abstract;
using Soenneker.Google.Meet.OpenApiClientUtil.Abstract;
using Soenneker.Google.Meet.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Google.Meet.OpenApiClientUtil;
public sealed class GoogleMeetOpenApiClientUtil : IGoogleMeetOpenApiClientUtil
{
    private readonly AsyncSingleton<GoogleMeetOpenApiClient> _client;

    public GoogleMeetOpenApiClientUtil(IGoogleMeetOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<GoogleMeetOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Google:Meet:AccessToken");
            string authHeaderName = configuration["Meet:AuthHeaderName"] ?? "Authorization";
            string authHeaderValueTemplate = configuration["Meet:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerName: authHeaderName, headerValue: authHeaderValue),
                httpClient: httpClient);

            return new GoogleMeetOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<GoogleMeetOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
