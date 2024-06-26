using ErrorOr;
using PharmacyCleanArchitecture.Domain.Common.Models;

namespace PharmacyCleanArchitecture.Domain.Users.ValueObjects;

public class PhoneNumber : ValueObject
{
    private const int MaxLength = 13;

    private PhoneNumber(string phone) => Value = phone;

    public static explicit operator string(PhoneNumber phoneNumber) => phoneNumber.Value;

    public string Value { get; set; }

    public static ErrorOr<PhoneNumber> Create(string phone)
    {
        if (phone.Length > MaxLength) return Error.Validation("PhoneNumber.Length", $"Phone number length cannot be greater than {MaxLength}");

        //TODO: Add more phone number validation

        return new PhoneNumber(phone);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}