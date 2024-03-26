using ErrorOr;
using MediatR;

namespace Pharmacy.Application.Users.MakeAdmin;

public record MakeAdminUserCommand(Guid UserId) : IRequest<ErrorOr<Updated>>;