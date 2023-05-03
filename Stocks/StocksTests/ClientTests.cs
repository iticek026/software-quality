using Stocks.Services.Exceptions;

namespace StocksTests;

public class ClientTests
{
    [Test]
    public async Task Client_RunAsync_DownloadServiceThrowsException()
    {
        var client = new MockedClient();
        client
            .CanNotDownloadData()
            .RunAsync()
            .AssertException(ExceptionStrings.GetExceptionMessage(CustomException.InvalidDownload));
    }

    [Test]
    public async Task Client_RunAsync_DownloadsEmptyFile()
    {
        var client = new MockedClient();
        client
            .DownloadEmptyData()
            .RunAsync()
            .AssertException(ExceptionStrings.GetExceptionMessage(CustomException.EmptyCsvFile));
    }

    [Test]
    public void Client_Run_ExportThrowsConnectionException()
    {
        var client = new MockedClient();
        client
            .CanDownloadData()
            .CanSaveContent()
            .CanGetLastAvailableFilePath()
            .CanParseData()
            .CanGetDifference()
            .CanNotConnectToSMTP()
            .RunAsync()
            .AssertException(ExceptionStrings.GetExceptionMessage(CustomException.SmtpConnectionException));
    }

    [Test]
    public void Client_Run_ExportThrowsAuthenticationException()
    {
        var client = new MockedClient();
        client
            .CanDownloadData()
            .CanSaveContent()
            .CanGetLastAvailableFilePath()
            .CanParseData()
            .CanGetDifference()
            .CanNotAuthenticateSMTP()
            .RunAsync()
            .AssertException(ExceptionStrings.GetExceptionMessage(CustomException.SmtpAuthenticationException));
    }

    [Test]
    public async Task Client_RunAsync_DateFileServiceThrowsException()
    {
        var client = new MockedClient();
        client
            .CanDownloadData()
            .CanSaveContent()
            .CanNotGetLastAvailableFilePath()
            .RunAsync()
            .AssertException(ExceptionStrings.GetExceptionMessage(CustomException.CsvFilePathNotFound));
    }

    [Test]
    public async Task Client_RunAsync_DateFileService_SaveContentThrowsException()
    {
        var client = new MockedClient();
        client
            .CanDownloadData()
            .CanNotSaveContent()
            .RunAsync()
            .AssertException(ExceptionStrings.GetExceptionMessage(CustomException.IoException));
    }

    [Test]
    public async Task Client_RunAsync_ParserThrowsMissingFieldException()
    {
        var client = new MockedClient();
        client
            .CanDownloadData()
            .CanSaveContent()
            .CanGetLastAvailableFilePath()
            .CanNotParseData()
            .RunAsync()
            .AssertException(ExceptionStrings.GetExceptionMessage(CustomException.MissingFieldException));
    }

    [Test]
    public async Task Client_RunAsync_SuccesfullyOutputsToConsole()
    {
        var client = new MockedClient();
        client
            .CanDownloadData()
            .CanSaveContent()
            .CanGetLastAvailableFilePath()
            .CanParseData()
            .CanGetDifference()
            .CanExportData()
            .RunAsync()
            .AssertContainsStockInfo("Microsoft");
    }
}