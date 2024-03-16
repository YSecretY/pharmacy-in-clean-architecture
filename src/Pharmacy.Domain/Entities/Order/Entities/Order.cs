using Pharmacy.Domain.Common.Primitives;
using Pharmacy.Domain.Entities.Enums;
using Pharmacy.Domain.ValueObjects;

namespace Pharmacy.Domain.Entities.Order.Entities;

public sealed class Order : Entity
{
    public Order(Guid id, Guid pharmacyId, Price totalPrice, OrderStatus status) : base(id)
    {
        PharmacyId = pharmacyId;
        TotalPrice = totalPrice;
        Status = status;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public Guid PharmacyId { get; set; }

    public Pharmacy.Entities.Pharmacy? Pharmacy { get; set; }

    public Price TotalPrice { get; set; }

    public OrderStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public List<Product.Entities.Product> Products { get; set; } = null!;
}