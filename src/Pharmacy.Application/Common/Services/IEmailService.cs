namespace Pharmacy.Application.Common.Services;

public interface IEmailService
{
    public Task SendConfirmationLetterAsync(string receiverEmail, string jwtConfirmationToken);
}