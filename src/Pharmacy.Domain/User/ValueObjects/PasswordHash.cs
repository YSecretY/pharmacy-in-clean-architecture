using ErrorOr;
using Pharmacy.Domain.Common.Models;

namespace Pharmacy.Domain.User.ValueObjects;

public class PasswordHash : ValueObject
{
    private const int MaxLength = 500;

    private PasswordHash(string password) => Value = password;

    public static explicit operator string(PasswordHash passwordHash) => passwordHash.Value;

    public string Value { get; }

    public static ErrorOr<PasswordHash> Create(string password)
    {
        if (password.Length > MaxLength) return Error.Validation("Password.TooLong", "Password is too long.");

        return new PasswordHash(password);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}