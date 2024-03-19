using ErrorOr;

namespace Pharmacy.Domain.Common.ValueObjects.CountryIsoCode;

public static class CountryIsoCodeErrors
{
    public static readonly Error LengthMustEqualsTwo =
        Error.Validation(code: "CountryIsoCode.LengthMustEqualsTwo", "Country iso code must be only 2 symbols length.");
}