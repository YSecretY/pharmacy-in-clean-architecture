using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.Enums;
using Pharmacy.Domain.ValueObjects;

namespace Pharmacy.Domain.Entities.Order.Entities;

public sealed class Order : Entity<Guid>
{
    public Order(Guid id, Guid pharmacyId, Price totalPrice, string address, OrderStatus status) : base(id)
    {
        PharmacyId = pharmacyId;
        TotalPrice = totalPrice;
        Address = address;
        Status = status;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public Guid PharmacyId { get; set; }

    public Pharmacy.Entities.Pharmacy? Pharmacy { get; set; }

    public Price TotalPrice { get; set; }

    public string Address { get; set; }

    public OrderStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public List<Product.Entities.Product> Products { get; set; } = null!;
}