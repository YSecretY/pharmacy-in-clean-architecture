using ErrorOr;
using Pharmacy.Domain.Common.Models;

namespace Pharmacy.Domain.Common.ValueObjects.Price;

public class Price : ValueObject
{
    private Price(decimal value)
    {
        Value = value;
    }

    public decimal Value { get; }

    public static ErrorOr<Price> Create(decimal price)
    {
        if (price < 0) return PriceErrors.CannotBeNegative;

        return new Price(price);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}