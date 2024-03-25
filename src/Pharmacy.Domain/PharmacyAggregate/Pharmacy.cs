using ErrorOr;
using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.Common.ValueObjects.CountryIsoCode;
using Pharmacy.Domain.Common.ValueObjects.Name;
using Pharmacy.Domain.PharmacyAggregate.Entities;

namespace Pharmacy.Domain.PharmacyAggregate;

public sealed class Pharmacy : AggregateRoot<Guid>
{
    private Pharmacy(Guid id, Name name, CountryIsoCode countryIsoCode) : base(id)
    {
        Name = name;
        CountryIsoCode = countryIsoCode;
    }

    public static ErrorOr<Pharmacy> Create(Guid id, string name, string countryIsoCode)
    {
        List<Error> errors = new();

        ErrorOr<Name> nameCreationResult = Name.Create(name);
        if (nameCreationResult.IsError) errors.AddRange(nameCreationResult.Errors);

        ErrorOr<CountryIsoCode> countryIsoCodeCreationResult = CountryIsoCode.Create(countryIsoCode);
        if (countryIsoCodeCreationResult.IsError) errors.AddRange(countryIsoCodeCreationResult.Errors);

        if (errors.Count is not 0) return errors;

        return new Pharmacy(
            id: id,
            name: nameCreationResult.Value,
            countryIsoCode: countryIsoCodeCreationResult.Value
        );
    }

    public Name Name { get; private set; }

    public CountryIsoCode CountryIsoCode { get; private set; }

    public List<Order> Orders { get; private set; } = null!;

    public List<Product> Products { get; private set; } = null!;
}