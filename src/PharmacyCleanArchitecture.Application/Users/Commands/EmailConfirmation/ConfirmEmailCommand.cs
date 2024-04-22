using ErrorOr;
using MediatR;

namespace PharmacyCleanArchitecture.Application.Users.Commands.EmailConfirmation;

public record ConfirmEmailCommand(string UserEmail, string EmailConfirmationToken) : IRequest<ErrorOr<Success>>;