namespace Pharmacy.Contracts.Users;

public record ChangeUserPasswordRequest(string OldPassword, string NewPassword, string NewPasswordConfirmation);