using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Common.Interfaces.Auth;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Domain.Users;

namespace Pharmacy.Application.Users.ChangeEmail;

public class ChangeEmailCommandHandler(
    IPharmacyDbContext dbContext,
    IJwtTokenValidator jwtTokenValidator
) : IRequestHandler<ChangeEmailCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(ChangeEmailCommand request, CancellationToken cancellationToken)
    {
        if (!await jwtTokenValidator.IsValidEmailConfirmationTokenAsync(request.ConfirmationToken))
            return Error.Forbidden(description: "Wrong email confirmation token.");

        User? user = await dbContext.Users
            .FirstOrDefaultAsync(u => (string)u.Email == request.OldEmail, cancellationToken);
        if (user is null) return Error.NotFound(description: "Couldn't find the user with the given id from claims.");

        ErrorOr<Updated> setEmailResult = user.SetEmail(request.NewEmail);
        if (setEmailResult.IsError) return setEmailResult.Errors;

        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Updated;
    }
}