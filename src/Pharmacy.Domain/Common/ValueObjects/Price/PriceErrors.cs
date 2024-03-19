using ErrorOr;

namespace Pharmacy.Domain.Common.ValueObjects.Price;

public static class PriceErrors
{
    public static readonly Error CannotBeNegative = Error.Validation(code: "Price.CannotBeNegative", "Price cannot be negative.");
}