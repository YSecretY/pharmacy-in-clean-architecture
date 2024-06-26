using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Identity;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;
using PharmacyCleanArchitecture.Application.Common.Services;
using PharmacyCleanArchitecture.Domain.Users;

namespace PharmacyCleanArchitecture.Application.Users.Commands.ChangePassword;

public class ChangePasswordCommandHandler(
    IPharmacyDbContext dbContext,
    IIdentityUserAccessor identityUserAccessor,
    IPasswordHasher passwordHasher
) : IRequestHandler<ChangePasswordCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        if (request.NewPassword != request.NewPasswordConfirmation)
            return Error.Validation(description: "Passwords are not equal.");

        Guid userId = identityUserAccessor.GetCurrentUserId();
        User? user = await dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        if (user is null) return Error.NotFound(description: "Couldn't find the user with the given id from claims.");

        if (!passwordHasher.Verify(request.OldPassword, user.PasswordHash.Value))
            return Error.Forbidden(description: "Invalid old password.");

        ErrorOr<Updated> setPasswordResult = user.SetPasswordHash(passwordHasher.HashPassword(request.NewPassword));
        if (setPasswordResult.IsError) return setPasswordResult.Errors;

        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Updated;
    }
}