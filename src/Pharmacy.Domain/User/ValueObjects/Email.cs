using ErrorOr;
using Pharmacy.Domain.Common.Models;

namespace Pharmacy.Domain.User.ValueObjects;

public class Email : ValueObject
{
    private Email(string email) => Value = email;

    public string Value { get; }

    public static ErrorOr<Email> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return Error.Validation("Email.Empty", "Email is empty.");

        //TODO: Add more email validation

        return new Email(email);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}