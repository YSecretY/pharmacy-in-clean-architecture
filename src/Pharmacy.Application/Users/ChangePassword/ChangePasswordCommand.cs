using ErrorOr;
using MediatR;

namespace Pharmacy.Application.Users.ChangePassword;

public record ChangePasswordCommand(string OldPassword, string NewPassword, string NewPasswordConfirmation) : IRequest<ErrorOr<Updated>>;