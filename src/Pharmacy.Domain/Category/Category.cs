using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.Pharmacy.ValueObjects;

namespace Pharmacy.Domain.Category;

public sealed class Category : Entity<Guid>
{
    public Category(Guid id, Name name) : base(id)
    {
        Name = name;
    }

    public Name Name { get; set; }
}