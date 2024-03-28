using ErrorOr;
using MediatR;

namespace PharmacyCleanArchitecture.Application.Users.Commands.Login;

public record LoginUserCommand(string Email, string Password) : IRequest<ErrorOr<string>>;