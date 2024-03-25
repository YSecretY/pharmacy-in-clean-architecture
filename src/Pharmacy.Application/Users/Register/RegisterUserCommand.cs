using ErrorOr;
using MediatR;

namespace Pharmacy.Application.Users.Register;

public record RegisterUserCommand
    (string Email, string Password, string? FirstName, string? PhoneNumber) : IRequest<ErrorOr<Created>>;