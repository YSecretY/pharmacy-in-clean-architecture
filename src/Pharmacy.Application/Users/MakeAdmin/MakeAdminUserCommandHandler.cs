using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Domain.Users;

namespace Pharmacy.Application.Users.MakeAdmin;

public class MakeAdminUserCommandHandler(
    IPharmacyDbContext dbContext
) : IRequestHandler<MakeAdminUserCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(MakeAdminUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);
        if (user is null) return Error.NotFound("User with given id is not found.");

        user.MakeAdmin();
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Updated;
    }
}