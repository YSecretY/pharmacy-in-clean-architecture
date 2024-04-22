using ErrorOr;
using MediatR;

namespace PharmacyCleanArchitecture.Application.Users.Commands.ChangeEmail;

public record SendEmailChangeConfirmationCommand(string ReceiverEmail) : IRequest<ErrorOr<Success>>;