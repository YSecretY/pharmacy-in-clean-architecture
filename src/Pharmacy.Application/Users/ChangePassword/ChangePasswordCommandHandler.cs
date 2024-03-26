using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Common.Interfaces.Identity;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Application.Common.Services;
using Pharmacy.Domain.User;

namespace Pharmacy.Application.Users.ChangePassword;

public class ChangePasswordCommandHandler(
    IPharmacyDbContext dbContext,
    IIdentityUserAccessor identityUserAccessor,
    IPasswordHasher passwordHasher
) : IRequestHandler<ChangePasswordCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        if (request.NewPassword != request.NewPasswordConfirmation)
            return Error.Validation(description: "Passwords are not equal.");

        Guid userId = identityUserAccessor.GetCurrentUserId();
        User? user = await dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        if (user is null) return Error.NotFound(description: "Couldn't find the user with the given id from claims.");

        if (!passwordHasher.Verify(request.OldPassword, user.PasswordHash.Value))
            return Error.Forbidden(description: "Invalid old password.");

        ErrorOr<Success> setPasswordResult = user.SetPasswordHash(passwordHasher.HashPassword(request.NewPassword));
        if (setPasswordResult.IsError) return setPasswordResult.Errors;

        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}