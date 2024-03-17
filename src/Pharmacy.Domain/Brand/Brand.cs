using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.Pharmacy.ValueObjects;

namespace Pharmacy.Domain.Brand;

public sealed class Brand : Entity<Guid>
{
    public Brand(Guid id, Name name) : base(id)
    {
        Name = name;
    }

    public Name Name { get; set; }
}