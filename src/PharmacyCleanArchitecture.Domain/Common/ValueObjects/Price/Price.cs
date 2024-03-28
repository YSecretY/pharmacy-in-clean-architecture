using ErrorOr;
using PharmacyCleanArchitecture.Domain.Common.Models;

namespace PharmacyCleanArchitecture.Domain.Common.ValueObjects.Price;

public class Price : ValueObject
{
    private Price(decimal value)
    {
        Value = value;
    }

    public static explicit operator decimal(Price price) => price.Value;

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