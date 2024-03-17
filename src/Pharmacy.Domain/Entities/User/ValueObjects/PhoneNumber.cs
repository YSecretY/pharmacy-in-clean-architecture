using ErrorOr;
using Pharmacy.Domain.Common.Models;

namespace Pharmacy.Domain.Entities.User.ValueObjects;

public class PhoneNumber : ValueObject
{
    private const int Length = 10;
    private PhoneNumber(string phone) => Value = phone;

    public string Value { get; set; }

    public static ErrorOr<PhoneNumber> Create(string phone)
    {
        if (phone.Length != 10) return Error.Validation("PhoneNumber.Length", $"Phone number length is not {Length}");

        //TODO: Add more phone number validation

        return new PhoneNumber(phone);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}