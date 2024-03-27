using ErrorOr;
using Pharmacy.Domain.Common.Models;

namespace Pharmacy.Domain.PharmacyAggregate.ValueObjects;

public class Sku : ValueObject
{
    private const int MaxLength = 20;

    private Sku(string sku) => Value = sku;

    public string Value { get; }

    public static explicit operator string(Sku sku) => sku.Value;

    public static ErrorOr<Sku> Create(string sku)
    {
        if (string.IsNullOrWhiteSpace(sku) || string.IsNullOrEmpty(sku))
            return Error.Validation("Sku.Empty", "Sku cannot be empty.");

        if (sku.Length > 20) return Error.Validation("Sku.TooLong", $"Sku cannot be longer than {MaxLength}");

        return new Sku(sku);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}