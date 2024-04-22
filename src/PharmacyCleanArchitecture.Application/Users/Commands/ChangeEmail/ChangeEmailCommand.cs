using ErrorOr;
using MediatR;

namespace PharmacyCleanArchitecture.Application.Users.Commands.ChangeEmail;

public record ChangeEmailCommand(string OldEmail, string NewEmail, string ConfirmationToken) : IRequest<ErrorOr<Updated>>;