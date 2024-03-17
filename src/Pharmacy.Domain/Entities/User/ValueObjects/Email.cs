using Pharmacy.Domain.Common.Models;
using ErrorOr;

namespace Pharmacy.Domain.Entities.User.ValueObjects;

public class Email : ValueObject
{
    private Email(string email) => Value = email;

    public string Value { get; }

    public static ErrorOr<Email> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return Error.Validation("Email.Emtpy", "Email is empty.");

        //TODO: Add more email validation

        return new Email(email);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}