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

    // Needs to take nullable for ef core
    public static ErrorOr<Price> Create(decimal? price)
    {
        return price switch
        {
            null => Error.Validation("Price.Null", "Price cannot be null"),
            < 0 => PriceErrors.CannotBeNegative,
            _ => new Price((decimal)price)
        };
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}