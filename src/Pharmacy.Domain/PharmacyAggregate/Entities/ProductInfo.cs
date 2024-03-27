using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.Common.ValueObjects.Price;
using Pharmacy.Domain.Products;

namespace Pharmacy.Domain.PharmacyAggregate.Entities;

public class ProductInfo : Entity<Guid>
{
    private ProductInfo(
        Guid id,
        Guid pharmacyId,
        Guid productId,
        int quantity,
        bool isInStock,
        Price discountedPrice
    ) : base(id)
    {
        PharmacyId = pharmacyId;
        ProductId = productId;
        Quantity = quantity;
        IsInStock = isInStock;
        DiscountedPrice = discountedPrice;
    }

    public Guid PharmacyId { get; private set; }
    
    public Pharmacy? Pharmacy { get; private set; }

    public Guid ProductId { get; private set; }
    
    public Product? Product { get; private set; }

    public int Quantity { get; private set; }

    public bool IsInStock { get; private set; }

    public Price DiscountedPrice { get; private set; }
}