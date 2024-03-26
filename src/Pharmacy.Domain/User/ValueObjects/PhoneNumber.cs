using ErrorOr;
using Pharmacy.Domain.Common.Models;

namespace Pharmacy.Domain.User.ValueObjects;

public class PhoneNumber : ValueObject
{
    private const int MaxLength = 13;
    private PhoneNumber(string phone) => Value = phone;

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