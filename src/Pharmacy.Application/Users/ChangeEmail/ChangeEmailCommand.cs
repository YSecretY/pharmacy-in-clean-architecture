using ErrorOr;
using MediatR;

namespace Pharmacy.Application.Users.ChangeEmail;

public record ChangeEmailCommand(string OldEmail, string NewEmail, string ConfirmationToken) : IRequest<ErrorOr<Updated>>;