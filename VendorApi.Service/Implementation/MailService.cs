using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;
using VendorApi.Domain.Settings;
using VendorApi.Service.Contract;
using VendorApi.Service.Exceptions;

namespace VendorApi.Service.Implementation
{
    public class MailService : IEmailService
    {
        public MailSettings _mailSettings { get; }
        public ILogger<MailService> _logger { get; }

        private readonly IConfiguration _configuration;

        public MailService(IOptions<MailSettings> mailSettings, ILogger<MailService> logger)
        {
            _mailSettings = mailSettings.Value;
            _logger = logger;
        }

        //public MailService(IConfiguration configuration, ILogger<MailService> logger)
        //{
        //    _configuration = configuration;
        //    _logger = logger;
        //}

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                // create message
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(mailRequest.From ?? _mailSettings.EmailFrom);
                //email.Sender = MailboxAddress.Parse(mailRequest.From ?? _configuration.GetValue<string>("MailSettings:Mail"));
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
                email.Subject = mailRequest.Subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.StartTls);
                //smtp.Connect(_configuration.GetValue<string>("MailSettings:Host"),
                //                _configuration.GetValue<int>("MailSettings:Port"),
                //                SecureSocketOptions.StartTls);

                smtp.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

    }
}