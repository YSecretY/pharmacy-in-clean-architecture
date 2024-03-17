using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.Entities.Pharmacy.ValueObjects;

namespace Pharmacy.Domain.Entities.Brand;

public sealed class Brand : Entity<Guid>
{
    public Brand(Guid id, Name name) : base(id)
    {
        Name = name;
    }

    public Name Name { get; set; }
}