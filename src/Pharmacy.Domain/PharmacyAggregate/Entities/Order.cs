using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.Common.ValueObjects;
using Pharmacy.Domain.Common.ValueObjects.Price;
using Pharmacy.Domain.PharmacyAggregate.Enums;

namespace Pharmacy.Domain.PharmacyAggregate.Entities;

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

    public Pharmacy? Pharmacy { get; set; }

    public Price TotalPrice { get; set; }

    public string Address { get; set; }

    public OrderStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public List<Product> Products { get; set; } = null!;
}