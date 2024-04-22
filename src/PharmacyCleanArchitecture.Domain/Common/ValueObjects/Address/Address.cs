using System.ComponentModel.DataAnnotations.Schema;
using ErrorOr;
using PharmacyCleanArchitecture.Domain.Common.Models;

namespace PharmacyCleanArchitecture.Domain.Common.ValueObjects.Address;

[ComplexType]
public class Address : ValueObject
{
    private Address(string street, string city, string postalCode, string country)
    {
        Street = street;
        City = city;
        PostalCode = postalCode;
        Country = country;
    }

    public string Street { get; private set; }

    public string City { get; private set; }

    public string PostalCode { get; private set; }

    public string Country { get; private set; }

    public static ErrorOr<Address> Create(string street, string city, string postalCode, string countryIsoCode)
    {
        //TODO: Add more address validation
        if (countryIsoCode.Length is < 2 or > 3)
            return Error.Validation("CountryIsoCode.Length", "Country iso code length must be 2 or 3.");
        countryIsoCode = countryIsoCode.ToLower();

        city = city.ToLower();
        postalCode = postalCode.ToLower();
        street = street.ToLower();

        return new Address(street, city, postalCode, countryIsoCode);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Street;
        yield return City;
        yield return PostalCode;
        yield return Country;
    }
}