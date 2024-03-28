using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Auth;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Identity;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;
using PharmacyCleanArchitecture.Application.Common.Services;
using PharmacyCleanArchitecture.Domain.Users.ValueObjects;

namespace PharmacyCleanArchitecture.Application.Users.Commands.ChangeEmail;

public class SendEmailChangeConfirmationCommandHandler(
    IPharmacyDbContext dbContext,
    IJwtTokenGenerator jwtTokenGenerator,
    IIdentityUserAccessor identityUserAccessor,
    IEmailService emailService
) : IRequestHandler<SendEmailChangeConfirmationCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(SendEmailChangeConfirmationCommand request, CancellationToken cancellationToken)
    {
        Guid userId = identityUserAccessor.GetCurrentUserId();
        Email? userEmail = await dbContext.Users
            .Where(u => u.Id == userId)
            .Select(u => u.Email)
            .FirstOrDefaultAsync(cancellationToken);
        if (userEmail is null) return Error.NotFound(description: "Couldn't find the user with the given id from claims.");

        ErrorOr<Email> newEmail = Email.Create(request.ReceiverEmail);
        if (newEmail.IsError) return newEmail.Errors;

        if (await dbContext.Users.AnyAsync(u => u.Email == newEmail.Value, cancellationToken))
            return Error.Conflict(description: "User with this email is already registered.");

        string confirmationToken = jwtTokenGenerator.GenerateEmailConfirmationToken(request.ReceiverEmail);

        await emailService.SendEmailChangeConfirmationLetterAsync(userEmail.Value, request.ReceiverEmail, confirmationToken);

        return Result.Success;
    }
}