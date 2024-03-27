using ErrorOr;
using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.Common.ValueObjects.Address;
using Pharmacy.Domain.Common.ValueObjects.Name;
using Pharmacy.Domain.PharmacyAggregate.Entities;

namespace Pharmacy.Domain.PharmacyAggregate;

public sealed class Pharmacy : AggregateRoot<Guid>
{
    private Pharmacy(Guid id) : base(id)
    {
    }

    public static ErrorOr<Pharmacy> Create(Guid id, string name, string street, string city, string postalCode, string countryIsoCode)
    {
        List<Error> errors = new();

        ErrorOr<Name> nameCreationResult = Name.Create(name);
        if (nameCreationResult.IsError) errors.AddRange(nameCreationResult.Errors);

        ErrorOr<Address> addressCreationResult = Address.Create(street, city, postalCode, countryIsoCode);
        if (addressCreationResult.IsError) errors.AddRange(addressCreationResult.Errors);

        if (errors.Count > 0) return errors;

        return new Pharmacy(id: id)
        {
            Name = nameCreationResult.Value,
            Address = addressCreationResult.Value
        };
    }

    public Name Name { get; private set; } = null!;

    public Address Address { get; private set; } = null!;

    public List<Order> Orders { get; private set; } = null!;
}