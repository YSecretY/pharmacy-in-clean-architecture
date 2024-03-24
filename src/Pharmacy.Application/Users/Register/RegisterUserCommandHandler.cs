using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Domain.User;
using Pharmacy.Domain.User.Enums;
using Pharmacy.Domain.User.ValueObjects;

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

        ErrorOr<Email> newUserEmail = Email.Create(request.Email);
        bool alreadyRegistered = await dbContext.Users
            .AnyAsync(u => u.Email == newUserEmail.Value, cancellationToken);
        if (alreadyRegistered) return Error.Conflict("User.Registered", "User with given email is already registered.");

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

        await dbContext.Users.AddAsync(userCreationResult.Value, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Created;
    }
}