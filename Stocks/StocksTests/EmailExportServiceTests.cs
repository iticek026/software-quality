using CsvHelper.Expressions;
using FakeItEasy;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Stocks.Services.Exceptions;
using Stocks.Services.Export;
using Stocks.Services.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksTests
{
    public class EmailExportServiceTests
    {
        private StringWriter? ConsoleError { get; set; }
        private IExportService _exportService;
        private ISmtpClient _smtpClient;
        private Settings _settings;

        public void Setup()
        {
            _smtpClient = A.Fake<ISmtpClient>();

            _settings = new Settings();
            _settings.CsvUrl =
                "https://ark-funds.com/wp-content/uploads/funds-etf-csv/ARK_INNOVATION_ETF_ARKK_HOLDINGS.csv";
            _settings.SaveDirectory = ".";
            _settings.FileExtension = ".csv";
            _settings.FileNameFormat = "dd_MM_yyyy";
            _settings.UserAgent = "StockService/1.0";
            _settings.Email.Sender = "a@a.a";
            _settings.Email.Recepients = new List<string>() { "a@a.a" };
            _settings.Email.SubjectTemplate = "Stocks for {0}";

            _exportService = new EmailExportService(_smtpClient, 
                _settings);

            ConsoleError = new StringWriter();
            Console.SetError(ConsoleError);
        }

        [Test]
        public void Export_SenderEmpty_ThrowsException()
        {
            // Arrange
            Setup();
            _settings.Email.Sender = null;

            // Act + Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _exportService.Export(""));
        }

        [Test]
        public async Task Export_SenderSpecified_ReturnsSuccess()
        {
            // Arrange
            Setup();

            // Assert
            Assert.DoesNotThrowAsync(async () => await _exportService.Export(""));
        }

        [Test]
        public void Export_SubjectEmpty_ThrowsException()
        {
            // Arrange
            Setup();
            _settings.Email.SubjectTemplate = null;

            // Act + Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _exportService.Export(""));
        }

        [Test]
        public async Task Export_SubjectSpecified_ReturnsSuccess()
        {
            // Arrange
            Setup();

            // Assert
            Assert.DoesNotThrowAsync(async () => await _exportService.Export(""));
        }

        [Test]
        public void Export_CanNotConnect_ThrowsException()
        {
            // Arrange
            Setup();
            A.CallTo(() => _smtpClient.ConnectAsync(_settings.Smtp.Host,
                _settings.Smtp.Port, 
                A<SecureSocketOptions>.Ignored, 
                A<CancellationToken>.Ignored))
            .Throws<Exception>();

            // Act + Assert
            Assert.ThrowsAsync<SmtpConnectionException>(() => _exportService.Export(""));
        }

        [Test]
        public void Export_CanNotAuthenticate_ThrowsException()
        {
            // Arrange
            Setup();

            A.CallTo(() => _smtpClient.ConnectAsync(_settings.Smtp.Host,
                _settings.Smtp.Port,
                A<SecureSocketOptions>.Ignored,
                A<CancellationToken>.Ignored))
               .Returns(Task.CompletedTask);
            A.CallTo(() => _smtpClient.AuthenticateAsync(_settings.Smtp.Username,
                _settings.Smtp.Password,
                A<CancellationToken>.Ignored))
            .Throws<Exception>();

            // Act + Assert
            Assert.ThrowsAsync<SmtpAuthenticationException>(() => _exportService.Export(""));
        }
    }
}
