using FakeItEasy;

namespace Stocks.Services.Download;

public class DownloadServiceTests
{
    private IDownloadService _downloadService;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _downloadService = A.Fake<IDownloadService>();
    }

    [Test]
    public async Task DownloadService_NotDownloaded_ThrowsCustomException()
    {
        A.CallTo(() => _downloadService.DownloadFile("invalid_path")).Throws<InvalidTimeZoneException>();
    }
}