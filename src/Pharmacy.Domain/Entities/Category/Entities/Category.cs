using Pharmacy.Domain.Common.Primitives;
using Pharmacy.Domain.ValueObjects;

namespace Pharmacy.Domain.Entities.Category.Entities;

public sealed class Category : Entity
{
    public Category(Guid id, Name name) : base(id)
    {
        Name = name;
    }

    public Name Name { get; set; }
}