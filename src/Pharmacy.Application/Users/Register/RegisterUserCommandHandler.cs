using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Domain.User;
using Pharmacy.Domain.User.Enums;

namespace Pharmacy.Application.Users.Register;

public class RegisterUserCommandHandler(
        IPharmacyDbContext dbContext,
        IValidator<RegisterUserCommand> validator)
    : IRequestHandler<RegisterUserCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.Errors.ConvertAll(validationFailure =>
                Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));
        }

        string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        ErrorOr<User> userCreationResult = User.Create(
            id: Guid.NewGuid(),
            email: request.Email,
            passwordHash: passwordHash,
            firstName: request.FirstName,
            phoneNumber: request.PhoneNumber,
            emailConfirmed: false,
            role: UserRole.DefaultUser
        );
        if (userCreationResult.IsError) return userCreationResult.Errors;

        try
        {
            await dbContext.Users.AddAsync(userCreationResult.Value, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException)
        {
            return Error.Conflict("User.AlreadyExists", "User with given email is already registered.");
        }

        return Result.Created;
    }
}