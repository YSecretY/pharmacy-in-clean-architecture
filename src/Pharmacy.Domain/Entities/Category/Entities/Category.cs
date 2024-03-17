using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.ValueObjects;

namespace Pharmacy.Domain.Entities.Category.Entities;

public sealed class Category : Entity<Guid>
{
    public Category(Guid id, Name name) : base(id)
    {
        Name = name;
    }

    public Name Name { get; set; }
}