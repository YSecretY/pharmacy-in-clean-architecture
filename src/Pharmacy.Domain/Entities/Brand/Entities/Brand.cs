using Pharmacy.Domain.Common.Primitives;
using Pharmacy.Domain.ValueObjects;

namespace Pharmacy.Domain.Entities.Brand.Entities;

public sealed class Brand : Entity
{
    public Brand(Guid id, Name name) : base(id)
    {
        Name = name;
    }

    public Name Name { get; set; }
}