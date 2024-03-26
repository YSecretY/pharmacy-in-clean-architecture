using ErrorOr;
using MediatR;

namespace Pharmacy.Application.Users.ChangeEmail;

public record SendEmailChangeConfirmationCommand(string ReceiverEmail) : IRequest<ErrorOr<Success>>;