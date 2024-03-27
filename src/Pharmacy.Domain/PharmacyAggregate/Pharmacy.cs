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

    public static ErrorOr<Pharmacy> Create(Guid id, string name, Address address)
    {
        List<Error> errors = new();

        ErrorOr<Name> nameCreationResult = Name.Create(name);
        if (nameCreationResult.IsError) errors.AddRange(nameCreationResult.Errors);

        if (errors.Count > 0) return errors;

        return new Pharmacy(id: id)
        {
            Name = nameCreationResult.Value,
            Address = address
        };
    }

    public Name Name { get; private set; } = null!;

    public Address Address { get; private set; } = null!;

    public List<Order> Orders { get; private set; } = null!;
}