﻿using Microsoft.Extensions.Configuration;
using Stocks.Services.Exceptions;
using Stocks.Services.Models.Configuration;

namespace Stocks.Services.Client;

public class DownloadService : IDownloadService
{
    private readonly HttpClient _client;
    private readonly Settings _settings;

    public DownloadService(Settings settings, 
        HttpClient client)
    {
        _settings = settings;
        _client = client;
    }

    public async Task<string?> DownloadFile(string path)
    {
        string? csv = null;
        var requestMessage = CreateGetRequestMessage(path);
       
        HttpResponseMessage responseMessage = await _client.SendAsync(requestMessage);
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new InvalidDownloadException(ExceptionStrings.GetExceptionMessage(CustomException.InvalidDownload));
        }

        csv = await responseMessage.Content.ReadAsStringAsync();

        return csv;
    }

    private HttpRequestMessage CreateGetRequestMessage(string url)
    {
        var request = new HttpRequestMessage()
        {
            RequestUri = new Uri(url),
            Method = HttpMethod.Get
        };
        request.Headers.Add("User-Agent", _settings.UserAgent);
        return request;
    }
}