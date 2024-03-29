using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Common.Interfaces.Auth;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Domain.User;
using Pharmacy.Domain.User.ValueObjects;

namespace Pharmacy.Application.Users.EmailConfirmation;

public class ConfirmEmailCommandHandler(
    IPharmacyDbContext dbContext,
    IJwtTokenValidator jwtTokenValidator
) : IRequestHandler<ConfirmEmailCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        User? user = await dbContext.Users
            .FirstOrDefaultAsync(u => (string)u.Email == request.UserEmail, cancellationToken);
        if (user is null) return Error.NotFound(description: "Couldn't find the user with the given email.");

        if (!await jwtTokenValidator.IsValidEmailConfirmationTokenAsync(request.EmailConfirmationToken))
            return Error.Forbidden(description: "Invalid email confirmation token.");

        user.ConfirmEmail();
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}