using ErrorOr;
using MediatR;

namespace PharmacyCleanArchitecture.Application.Users.Commands.MakeAdmin;

public record MakeAdminUserCommand(Guid UserId) : IRequest<ErrorOr<Updated>>;