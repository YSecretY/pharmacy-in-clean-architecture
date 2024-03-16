using Pharmacy.Domain.Common.Models;

namespace Pharmacy.Domain.Entities.Brand.Entities;

public sealed class Brand : Entity
{
    public Brand(Guid id, string name) : base(id)
    {
        Name = name;
    }

    public string Name { get; set; }
}