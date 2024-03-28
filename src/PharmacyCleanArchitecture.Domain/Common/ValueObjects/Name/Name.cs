using ErrorOr;
using PharmacyCleanArchitecture.Domain.Common.Models;

namespace PharmacyCleanArchitecture.Domain.Common.ValueObjects.Name;

public class Name : ValueObject
{
    private const int MaxLength = 100;

    private Name(string name) => Value = name;

    public string Value { get; }

    public static ErrorOr<Name> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(name)) return NameErrors.CannotBeNullOrEmpty;

        if (name.Length > MaxLength) return NameErrors.CannotBeTooLong;

        return new Name(name);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}