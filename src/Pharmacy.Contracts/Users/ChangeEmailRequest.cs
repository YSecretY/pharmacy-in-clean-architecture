namespace Pharmacy.Contracts.Users;

public record ChangeEmailRequest(string OldEmail, string NewEmail, string ConfirmationToken);