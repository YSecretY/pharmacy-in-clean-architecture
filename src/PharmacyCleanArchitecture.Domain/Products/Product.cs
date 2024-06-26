using ErrorOr;
using PharmacyCleanArchitecture.Domain.Brands;
using PharmacyCleanArchitecture.Domain.Categories;
using PharmacyCleanArchitecture.Domain.Common.Models;
using PharmacyCleanArchitecture.Domain.Common.ValueObjects.Name;
using PharmacyCleanArchitecture.Domain.Common.ValueObjects.Price;
using PharmacyCleanArchitecture.Domain.PharmacyAggregate.ValueObjects;

namespace PharmacyCleanArchitecture.Domain.Products;

public sealed class Product : Entity<Guid>
{
    private Product(
        Guid id,
        Name name,
        Sku? sku,
        string imageUrl,
        Guid brandId,
        Guid categoryId,
        Price price,
        string? description
    ) : base(id)
    {
        Name = name;
        Sku = sku;
        ImageUrl = imageUrl;
        BrandId = brandId;
        CategoryId = categoryId;
        Price = price;
        Description = description;
    }

    public static ErrorOr<Product> Create(
        Guid id,
        string name,
        string? sku,
        string imageUrl,
        Guid brandId,
        Guid categoryId,
        decimal price,
        string? description
    )
    {
        List<Error> errors = new();

        ErrorOr<Name> nameCreationResult = Name.Create(name);
        if (nameCreationResult.IsError) errors.AddRange(nameCreationResult.Errors);

        ErrorOr<Price> priceCreationResult = Price.Create(price);
        if (priceCreationResult.IsError) errors.AddRange(priceCreationResult.Errors);

        ErrorOr<Sku> skuCreationResult = new();
        if (sku is not null)
        {
            skuCreationResult = Sku.Create(sku);
            if (skuCreationResult.IsError) errors.AddRange(skuCreationResult.Errors);
        }

        if (errors.Count is not 0) return errors;

        return new Product(
            id: id,
            name: nameCreationResult.Value,
            sku: sku is null ? null : skuCreationResult.Value,
            imageUrl: imageUrl,
            brandId: brandId,
            categoryId: categoryId,
            price: priceCreationResult.Value,
            description: description
        );
    }

    public Name Name { get; private set; }

    public Sku? Sku { get; private set; }

    public string ImageUrl { get; private set; }

    public Guid BrandId { get; private set; }

    public Brand Brand { get; private set; } = null!;

    public Guid CategoryId { get; private set; }

    public Category Category { get; private set; } = null!;

    public Price Price { get; private set; }

    public string? Description { get; private set; }
}