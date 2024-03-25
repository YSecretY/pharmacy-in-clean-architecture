using MediatR;
using ErrorOr;

namespace Pharmacy.Application.Users.Login;

public record LoginUserCommand(string Email, string Password) : IRequest<ErrorOr<string>>;