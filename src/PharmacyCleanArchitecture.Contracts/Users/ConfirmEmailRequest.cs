namespace PharmacyCleanArchitecture.Contracts.Users;

public record ConfirmEmailRequest(string UserEmail, string EmailConfirmationToken);