using Pharmacy.Domain.Common.Primitives;
using Pharmacy.Domain.ValueObjects;

namespace Pharmacy.Domain.Entities.Product.Entities;

public sealed class Product : Entity<Guid>
{
    public Product(
        Guid id,
        Name name,
        string imageUrl,
        Guid brandId,
        Guid categoryId,
        Price price,
        Guid countryId,
        string? description,
        Guid? orderId) : base(id)
    {
        Name = name;
        ImageUrl = imageUrl;
        BrandId = brandId;
        CategoryId = categoryId;
        Price = price;
        CountryId = countryId;
        Description = description;
        OrderId = orderId;
    }

    public Name Name { get; set; }

    public string ImageUrl { get; set; }

    public Guid BrandId { get; set; }

    public Brand.Entities.Brand? Brand { get; set; }

    public Guid CategoryId { get; set; }

    public Category.Entities.Category? Category { get; set; }

    public Price Price { get; set; }

    public Guid CountryId { get; set; }

    public Country.Entities.Country? Country { get; set; }

    public string? Description { get; set; }

    public List<Pharmacy.Entities.Pharmacy> Pharmacies { get; set; } = null!;

    public Guid? OrderId { get; set; }

    public Order.Entities.Order? Order { get; set; }
}