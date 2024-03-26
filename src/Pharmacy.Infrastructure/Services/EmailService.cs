using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using Pharmacy.Application.Common.Services;

namespace Pharmacy.Infrastructure.Services;

public class EmailService(
    IOptions<SmtpClientSettings> smtpClientOptions
) : IEmailService, IDisposable
{
    private readonly SmtpClientSettings _smtpClientSettings = smtpClientOptions.Value;
    private readonly SmtpClient _smtpClient = new();

    public async Task SendConfirmationLetterAsync(string receiverEmail, string jwtConfirmationToken)
    {
        MimeMessage confirmEmailMessage = new();
        confirmEmailMessage.From.Add(new MailboxAddress(_smtpClientSettings.Name, _smtpClientSettings.Gmail));
        confirmEmailMessage.To.Add(MailboxAddress.Parse(receiverEmail));
        confirmEmailMessage.Subject = "Pharmacy confirmation letter.";

        BodyBuilder bodyBuilder = new()
        {
            TextBody =
                $"Hi! Welcome to the Pharmacy, click on the link to confirm your email. {_smtpClientSettings.BaseApplicationUrl}/users/confirm-email?EmailConfirmationToken={jwtConfirmationToken}&UserEmail={receiverEmail}"
        };

        confirmEmailMessage.Body = bodyBuilder.ToMessageBody();
        if (!_smtpClient.IsConnected)
        {
            await _smtpClient.ConnectAsync(_smtpClientSettings.Server, _smtpClientSettings.Port, _smtpClientSettings.SslEnabled);
            await _smtpClient.AuthenticateAsync(_smtpClientSettings.Gmail, _smtpClientSettings.Password);
        }

        await _smtpClient.SendAsync(confirmEmailMessage);
    }

    public async Task SendEmailChangeConfirmationLetterAsync(string oldEmail, string receiverEmail, string jwtConfirmationToken)
    {
        MimeMessage confirmEmailMessage = new();
        confirmEmailMessage.From.Add(new MailboxAddress(_smtpClientSettings.Name, _smtpClientSettings.Gmail));
        confirmEmailMessage.To.Add(MailboxAddress.Parse(receiverEmail));
        confirmEmailMessage.Subject = "Pharmacy confirmation letter.";

        BodyBuilder bodyBuilder = new()
        {
            TextBody =
                $"Hi! Please, click on the link if you would like to confirm email change. {_smtpClientSettings.BaseApplicationUrl}/users/change-email?ConfirmationToken={jwtConfirmationToken}&OldEmail={oldEmail}&NewEmail={receiverEmail}"
        };

        confirmEmailMessage.Body = bodyBuilder.ToMessageBody();
        if (!_smtpClient.IsConnected)
        {
            await _smtpClient.ConnectAsync(_smtpClientSettings.Server, _smtpClientSettings.Port, _smtpClientSettings.SslEnabled);
            await _smtpClient.AuthenticateAsync(_smtpClientSettings.Gmail, _smtpClientSettings.Password);
        }

        await _smtpClient.SendAsync(confirmEmailMessage);
    }

    public void Dispose()
    {
        _smtpClient.Disconnect(quit: true);
        _smtpClient.Dispose();

        GC.SuppressFinalize(this);
    }
}

public class SmtpClientSettings
{
    public const string SectionName = "SmtpClientOptions";

    public string Server { get; init; } = null!;

    public int Port { get; init; }

    public bool SslEnabled { get; init; }

    public string BaseApplicationUrl { get; init; } = null!;

    public string Name { get; init; } = null!;

    public string Gmail { get; init; } = null!;

    public string Password { get; init; } = null!;
}