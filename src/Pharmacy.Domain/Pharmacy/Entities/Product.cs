using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.Pharmacy.ValueObjects;

namespace Pharmacy.Domain.Pharmacy.Entities;

public sealed class Product : Entity<Guid>
{
    public Product(
        Guid id,
        Name name,
        string imageUrl,
        Guid brandId,
        Guid categoryId,
        Price price,
        string? description) : base(id)
    {
        Name = name;
        ImageUrl = imageUrl;
        BrandId = brandId;
        CategoryId = categoryId;
        Price = price;
        Description = description;
    }

    public Name Name { get; set; }

    public string ImageUrl { get; set; }

    public Guid BrandId { get; set; }

    public Brand.Brand? Brand { get; set; }

    public Guid CategoryId { get; set; }

    public Category.Category? Category { get; set; }

    public Price Price { get; set; }

    public string? CountryIsoCode { get; set; }

    public string? Description { get; set; }

    public List<Pharmacy> Pharmacies { get; set; } = null!;

    public bool IsInStock { get; set; }
}