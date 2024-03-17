using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.Entities.Pharmacy.ValueObjects;

namespace Pharmacy.Domain.Entities.Category;

public sealed class Category : Entity<Guid>
{
    public Category(Guid id, Name name) : base(id)
    {
        Name = name;
    }

    public Name Name { get; set; }
}