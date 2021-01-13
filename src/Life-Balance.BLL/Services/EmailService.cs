using System;
using Life_Balance.Common.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;
using Life_Balance.BLL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Life_Balance.BLL.Services
{
    /// <summary>
    /// Email service.
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly MailSettings _mailConfig;

        public EmailService()
        {
            _mailConfig = MailKitConfiguration();
        }
        
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Life Balance", _mailConfig.EmailAddress));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_mailConfig.Server, _mailConfig.Port, false);
                await client.AuthenticateAsync(_mailConfig.EmailAddress,_mailConfig.Password);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
        
        private MailSettings MailKitConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("mailsettings.json")
                .Build();

            var mailSettingSection = configuration.GetSection("MailSettings");

            return (MailSettings)mailSettingSection;
        }
    }
}
