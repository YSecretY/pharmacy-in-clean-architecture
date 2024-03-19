using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.PharmacyAggregate.ValueObjects;

namespace Pharmacy.Domain.Category;

public sealed class Category : Entity<Guid>
{
    public Category(Guid id, Name name, string imageUrl) : base(id)
    {
        Name = name;
        ImageUrl = imageUrl;
    }

    public Name Name { get; set; }
    
    public string? ImageUrl { get; set; }
}