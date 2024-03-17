using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.ValueObjects;

namespace Pharmacy.Domain.Entities.Brand.Entities;

public sealed class Brand : Entity<Guid>
{
    public Brand(Guid id, Name name) : base(id)
    {
        Name = name;
    }

    public Name Name { get; set; }
}