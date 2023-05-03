using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Stocks.Services.Models.Configuration;

namespace Stocks.Services.Export
{
    /// <summary>
    /// Class <c>EmailExportService</c> defines the service that exports content via email.
    /// </summary>
    public class EmailExportService : IExportService, IDisposable
    {
        private readonly ISmtpClient _smtpClient;
        private readonly Settings _settings;

        /// <summary>
        /// Creates a new instance of <see cref="EmailExportService"/>.
        /// </summary>
        /// <param name="settings">Settings.</param>
        /// <param name="smtpClient">SMTP Client implementation</param>
        public EmailExportService(ISmtpClient smtpClient,
            Settings settings)
        {
            _smtpClient = smtpClient;
            _settings = settings;
        }

        public void Dispose()
        {
            if (_smtpClient.IsConnected)
            {
                _smtpClient.Disconnect(true);
            }
            _smtpClient.Dispose();
        }

        /// <summary>
        /// Sends the content via email asynchronously.
        /// </summary>
        /// <param name="content">The content to be sent.</param>
        public async Task Export(string content)
        {
            var message = CreateBaseMailMessage();

            message.Body = CreateBody(content);

            await _smtpClient.ConnectAsync(_settings.Smtp.Host, _settings.Smtp.Port, SecureSocketOptions.SslOnConnect);
            await _smtpClient.AuthenticateAsync(_settings.Smtp.Username, _settings.Smtp.Password);
            await _smtpClient.SendAsync(message);
            await _smtpClient.DisconnectAsync(true);

            return;
        }

        /// <summary>
        /// Creates the mail message with the base configuration from the settings.
        /// </summary>
        /// <returns><c>MimeMessage</c> object.</returns>
        private MimeMessage CreateBaseMailMessage()
        {
            var mailMessage = new MimeMessage();

            mailMessage.From.Add(new MailboxAddress("Stocks", _settings.Email.Sender));

            foreach (var recipient in _settings.Email.Recepients)
            {
                mailMessage.To.Add(new MailboxAddress(recipient, recipient));
            }

            mailMessage.Subject = string.Format(_settings.Email.SubjectTemplate, DateTime.Today.ToShortDateString());

            return mailMessage;
        }

        /// <summary>
        /// Creates the body of the email.
        /// </summary>
        /// <param name="content">The content of the email.</param>
        /// <returns><c>MimeEntity</c> object.</returns>
        private MimeEntity CreateBody(string content)
        {
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = content
            };
            return bodyBuilder.ToMessageBody();
        }
    }
}