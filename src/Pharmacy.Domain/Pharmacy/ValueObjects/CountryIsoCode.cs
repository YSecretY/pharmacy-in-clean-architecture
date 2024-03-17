using ErrorOr;
using Pharmacy.Domain.Common.Models;

namespace Pharmacy.Domain.Pharmacy.ValueObjects;

public class CountryIsoCode : ValueObject
{
    private const int Length = 2;

    private CountryIsoCode(string code) => Value = code;

    public string Value { get; }

    public static ErrorOr<CountryIsoCode> Create(string code)
    {
        if (code.Length != 2) return Error.Validation("CountryIsoCode.Length", $"CountryIsoCode length is not {Length}.");

        return new CountryIsoCode(code);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}