namespace PharmacyCleanArchitecture.Application.Common.Services;

public interface IEmailService
{
    public Task SendConfirmationLetterAsync(string receiverEmail, string jwtConfirmationToken);

    public Task SendEmailChangeConfirmationLetterAsync(string oldEmail, string receiverEmail, string jwtConfirmationToken);
}