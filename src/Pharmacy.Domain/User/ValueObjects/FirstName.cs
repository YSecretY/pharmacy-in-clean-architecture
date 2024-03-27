using ErrorOr;
using Pharmacy.Domain.Common.Models;

namespace Pharmacy.Domain.User.ValueObjects;

public class FirstName : ValueObject
{
    private const int MaxLength = 100;

    private FirstName(string value) => Value = value;

    public string Value { get; }

    public static explicit operator string(FirstName firstName) => firstName.Value;

    public static ErrorOr<FirstName> Create(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName)) return Error.Validation("FirstName.Empty", "First name is empty.");

        if (firstName.Length > MaxLength) return Error.Validation("FirstName.TooLong", "First name is too long.");

        return new FirstName(firstName);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}