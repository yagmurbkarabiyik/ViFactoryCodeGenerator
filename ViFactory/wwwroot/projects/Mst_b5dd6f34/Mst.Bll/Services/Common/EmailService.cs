using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Security;
using Mst.Core.Services;
using Mst.Bll.Models;
using Mst.Core.Models;

namespace Mst.Bll.Services.Common
{
    public class EmailService : IEmailService
    { 
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<(bool IsSuccess, Exception? Exception)> SendAsync(EmailSendData emailData, CancellationToken? ct = default)
        {
            try
            {
                var mail = new MimeMessage();

                #region Sender / Receiver
                mail.From.Add(new MailboxAddress(emailData.DisplayName ?? _settings.DisplayName, emailData.From ?? _settings.From));

                mail.Sender = new MailboxAddress(emailData.DisplayName ?? _settings.DisplayName, emailData.From ?? _settings.From);

                mail.To.AddRange(emailData.To.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => MailboxAddress.Parse(x.Trim())));

                if (!string.IsNullOrEmpty(emailData.ReplyTo))
                    mail.ReplyTo.Add(new MailboxAddress(emailData.ReplyToName, emailData.ReplyTo));

                if (emailData.Bcc != null)
                    mail.Bcc.AddRange(emailData.Bcc.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => MailboxAddress.Parse(x.Trim())));

                if (emailData.Cc != null)
                    mail.Cc.AddRange(emailData.Cc.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => MailboxAddress.Parse(x.Trim())));
                #endregion

                #region Content

                var body = new BodyBuilder();
                mail.Subject = emailData.Subject;
                body.HtmlBody = emailData.Body;
                mail.Body = body.ToMessageBody();

                #endregion

                #region Send Mail

                using var smtp = new MailKit.Net.Smtp.SmtpClient();

                if (_settings.UseSSL)
                {
                    await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.SslOnConnect, ct ?? default);
                }
                else if (_settings.UseStartTls)
                {
                    await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls, ct ?? default);
                }
                await smtp.AuthenticateAsync(_settings.UserName, _settings.Password, ct ?? default);
                await smtp.SendAsync(mail, ct ?? default);
                await smtp.DisconnectAsync(true, ct ?? default);

                #endregion

                return (true, null);

            }
            catch (Exception ex)
            {
                return (false, ex);
            }
        }
    }
}