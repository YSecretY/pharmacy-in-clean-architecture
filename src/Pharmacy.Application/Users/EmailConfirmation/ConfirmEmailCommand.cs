using ErrorOr;
using MediatR;

namespace Pharmacy.Application.Users.EmailConfirmation;

public record ConfirmEmailCommand(string UserEmail, string EmailConfirmationToken) : IRequest<ErrorOr<Success>>;