using ErrorOr;
using MediatR;

namespace PharmacyCleanArchitecture.Application.Users.Commands.Register;

public record RegisterUserCommand
    (string Email, string Password, string? FirstName, string? PhoneNumber) : IRequest<ErrorOr<Created>>;