using ErrorOr;
using PharmacyCleanArchitecture.Domain.Common.Models;
using PharmacyCleanArchitecture.Domain.Common.ValueObjects.Address;
using PharmacyCleanArchitecture.Domain.Common.ValueObjects.Name;
using PharmacyCleanArchitecture.Domain.OrderAggregate;

namespace PharmacyCleanArchitecture.Domain.PharmacyAggregate;

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

    public DateTime CreatedAt { get; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
}