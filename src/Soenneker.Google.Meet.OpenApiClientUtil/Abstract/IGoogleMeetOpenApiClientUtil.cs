using Soenneker.Google.Meet.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Google.Meet.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IGoogleMeetOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<GoogleMeetOpenApiClient> Get(CancellationToken cancellationToken = default);
}
