using ErrorOr;
using MediatR;

namespace PharmacyCleanArchitecture.Application.Users.Commands.ChangePassword;

public record ChangePasswordCommand(string OldPassword, string NewPassword, string NewPasswordConfirmation) : IRequest<ErrorOr<Updated>>;