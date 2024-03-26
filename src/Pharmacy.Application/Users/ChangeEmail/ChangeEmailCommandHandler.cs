using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Common.Interfaces.Auth;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Domain.User;
using Pharmacy.Domain.User.ValueObjects;

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

        ErrorOr<Email> oldEmail = Email.Create(request.OldEmail);
        User? user = await dbContext.Users
            .FirstOrDefaultAsync(u => u.Email == oldEmail.Value, cancellationToken);
        if (user is null) return Error.NotFound(description: "Couldn't find the user with the given id from claims.");

        user.SetEmail(request.NewEmail);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Updated;
    }
}