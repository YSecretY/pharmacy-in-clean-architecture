using PharmacyCleanArchitecture.Domain.Common.Models;
using PharmacyCleanArchitecture.Domain.Common.ValueObjects.Price;
using PharmacyCleanArchitecture.Domain.Products;
using ErrorOr;

namespace PharmacyCleanArchitecture.Domain.PharmacyAggregate.Entities;

public class ProductInfo : Entity<Guid>
{
    private ProductInfo(
        Guid id,
        Guid pharmacyId,
        Guid productId,
        int quantity,
        bool isInStock,
        Price? discountedPrice
    ) : base(id)
    {
        PharmacyId = pharmacyId;
        ProductId = productId;
        Quantity = quantity;
        IsInStock = isInStock;
        DiscountedPrice = discountedPrice;
    }

    public static ErrorOr<ProductInfo> Create(
        Guid id,
        Guid pharmacyId,
        Guid productId,
        int quantity,
        bool isInStock,
        decimal? discountedPrice
    )
    {
        ErrorOr<Price> priceCreationResult = new();
        if (discountedPrice is not null)
        {
            priceCreationResult = Price.Create(discountedPrice.Value);
            if (priceCreationResult.IsError) return priceCreationResult.Errors;
        }

        if (quantity < 0) return Error.Validation("Quantity.Negative", "Quantity cannot be negative.");

        return new ProductInfo(
            id: id,
            pharmacyId: pharmacyId,
            productId: productId,
            quantity: quantity,
            isInStock: isInStock,
            discountedPrice: priceCreationResult.Value
        );
    }

    public ErrorOr<Updated> Buy(int quantity)
    {
        if (Quantity < quantity) return Error.Validation("Quantity.Negative", "Quantity cannot be negative.");

        Quantity -= quantity;

        if (Quantity is 0) IsInStock = false;

        return Result.Updated;
    }

    public Guid PharmacyId { get; private set; }

    public Pharmacy Pharmacy { get; private set; }

    public Guid ProductId { get; private set; }

    public Product Product { get; private set; }

    public int Quantity { get; private set; }

    public bool IsInStock { get; private set; }

    public Price? DiscountedPrice { get; private set; }
}