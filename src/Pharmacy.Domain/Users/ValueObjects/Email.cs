using ErrorOr;
using Pharmacy.Domain.Common.Models;

namespace Pharmacy.Domain.Users.ValueObjects;

public class Email : ValueObject
{
    public const int MaxLength = 100;
    private Email(string email) => Value = email;

    public string Value { get; }

    public static explicit operator string(Email email) => email.Value;

    public static ErrorOr<Email> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return Error.Validation("Email.Empty", "Email is empty.");

        if (email.Length > MaxLength) return Error.Validation("Email.TooLong", "Email is too long.");

        //TODO: Add more email validation

        return new Email(email);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}