using ErrorOr;
using Pharmacy.Domain.Common.Models;

namespace Pharmacy.Domain.Pharmacy.ValueObjects;

public class Price : ValueObject
{
    private Price(decimal value)
    {
        Value = value;
    }

    public decimal Value { get; }

    public static ErrorOr<Price> Create(decimal price)
    {
        if (price < 0) return Error.Validation("Price.Negative", "Price is negative.");

        return new Price(price);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}