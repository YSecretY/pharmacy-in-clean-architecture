using ErrorOr;
using Pharmacy.Domain.Common.Models;

namespace Pharmacy.Domain.Entities.Pharmacy.ValueObjects;

public class Name : ValueObject
{
    private const int MaxLength = 100;

    private Name(string name) => Value = name;

    public string Value { get; }

    public static ErrorOr<Name> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return Error.Validation("Name.Empty", "Name is empty.");

        if (name.Length > MaxLength) return Error.Validation("Name.TooLong", "Name if too long");

        return new Name(name);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}