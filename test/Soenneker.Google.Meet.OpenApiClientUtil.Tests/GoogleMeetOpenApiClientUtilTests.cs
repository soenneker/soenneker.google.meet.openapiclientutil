using Soenneker.Google.Meet.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Google.Meet.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class GoogleMeetOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IGoogleMeetOpenApiClientUtil _openapiclientutil;

    public GoogleMeetOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IGoogleMeetOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
