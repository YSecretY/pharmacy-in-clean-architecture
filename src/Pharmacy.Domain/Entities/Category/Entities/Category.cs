using Pharmacy.Domain.Common.Models;

namespace Pharmacy.Domain.Entities.Category.Entities;

public sealed class Category : Entity
{
    public Category(Guid id, string name) : base(id)
    {
        Name = name;
    }

    public string Name { get; set; }
}