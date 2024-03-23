using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.User.Enums;
using Pharmacy.Domain.User.ValueObjects;
using ErrorOr;

namespace Pharmacy.Domain.User;

public class User : Entity<Guid>
{
    private User(
        Guid id,
        Email email,
        FirstName? firstName,
        bool emailConfirmed,
        PasswordHash passwordHash,
        UserRole? role,
        PhoneNumber? phoneNumber
    ) : base(id)
    {
        Email = email;
        FirstName = firstName;
        EmailConfirmed = emailConfirmed;
        PasswordHash = passwordHash;
        Role = role ?? UserRole.DefaultUser;
        PhoneNumber = phoneNumber;
    }

    internal static ErrorOr<User> Create(
        Guid id,
        string email,
        string firstName,
        bool emailConfirmed,
        string passwordHash,
        UserRole? role,
        string phoneNumber
    )
    {
        List<Error> errors = new();

        ErrorOr<Email> emailCreationResult = Email.Create(email);
        if (emailCreationResult.IsError) errors.AddRange(emailCreationResult.Errors);

        ErrorOr<FirstName> firstNameCreationResult = FirstName.Create(firstName);
        if (firstNameCreationResult.IsError) errors.AddRange(firstNameCreationResult.Errors);

        ErrorOr<PasswordHash> passwordHashCreationResult = PasswordHash.Create(passwordHash);
        if (passwordHashCreationResult.IsError) errors.AddRange(passwordHashCreationResult.Errors);

        ErrorOr<PhoneNumber> phoneNumberCreationResult = PhoneNumber.Create(phoneNumber);
        if (phoneNumberCreationResult.IsError) errors.AddRange(phoneNumberCreationResult.Errors);

        if (errors.Count is not 0) return errors;

        return new User(
            id: id,
            email: emailCreationResult.Value,
            firstName: firstNameCreationResult.Value,
            emailConfirmed: emailConfirmed,
            passwordHash: passwordHashCreationResult.Value,
            role: role,
            phoneNumber: phoneNumberCreationResult.Value
        );
    }

    public ErrorOr<Success> SetEmail(string email)
    {
        ErrorOr<Email> emailCreationResult = Email.Create(email);
        if (emailCreationResult.IsError) return emailCreationResult.Errors;

        Email = emailCreationResult.Value;

        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
    }

    public ErrorOr<Success> SetPasswordHash(string passwordHash)
    {
        ErrorOr<PasswordHash> passwordHashCreationResult = PasswordHash.Create(passwordHash);
        if (passwordHashCreationResult.IsError) return passwordHashCreationResult.Errors;

        PasswordHash = passwordHashCreationResult.Value;

        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
    }

    public void MakeAdmin()
    {
        Role = UserRole.Admin;

        UpdatedAt = DateTime.UtcNow;
    }

    public void ConfirmEmail()
    {
        EmailConfirmed = true;

        UpdatedAt = DateTime.UtcNow;
    }

    public ErrorOr<Success> SetPhoneNumber(string phoneNumber)
    {
        ErrorOr<PhoneNumber> phoneNumberCreationResult = PhoneNumber.Create(phoneNumber);
        if (phoneNumberCreationResult.IsError) return phoneNumberCreationResult.Errors;

        PhoneNumber = phoneNumberCreationResult.Value;

        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
    }

    public Email Email { get; private set; }

    public FirstName? FirstName { get; private set; }

    public bool EmailConfirmed { get; private set; }

    public PasswordHash PasswordHash { get; private set; }

    public PhoneNumber? PhoneNumber { get; private set; }

    public UserRole Role { get; private set; }

    public DateTime CreatedAt { get; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
}