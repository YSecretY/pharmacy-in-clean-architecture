using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.Common.ValueObjects.Price;
using Pharmacy.Domain.PharmacyAggregate.Enums;

namespace Pharmacy.Domain.PharmacyAggregate.Entities;

public sealed class Order(
        Guid id,
        Guid pharmacyId,
        Price totalPrice,
        string address,
        OrderStatus status)
    : Entity<Guid>(id)
{
    public Guid PharmacyId { get; set; } = pharmacyId;

    public Pharmacy? Pharmacy { get; set; }

    public Price TotalPrice { get; set; } = totalPrice;

    public string Address { get; set; } = address;

    public OrderStatus Status { get; set; } = status;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public List<Product> Products { get; set; } = null!;
}