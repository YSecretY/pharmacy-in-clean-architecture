using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Common.Interfaces.Identity;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Domain.Users;

namespace Pharmacy.Application.Users.UpdatePhoneNumber;

public class UpdatePhoneNumberUserCommandHandler(
    IPharmacyDbContext dbContext,
    IIdentityUserAccessor identityUserAccessor
) : IRequestHandler<UpdatePhoneNumberUserCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdatePhoneNumberUserCommand request, CancellationToken cancellationToken)
    {
        Guid userId = identityUserAccessor.GetCurrentUserId();

        User? user = await dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        if (user is null) return Error.NotFound("User with the given user id from claims is not found.");

        ErrorOr<Updated> setPhoneNumberResult = user.SetPhoneNumber(request.PhoneNumber);
        if (setPhoneNumberResult.IsError) return setPhoneNumberResult.Errors;

        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Updated;
    }
}