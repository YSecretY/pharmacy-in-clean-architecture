using Pharmacy.Domain.Entities.Enums;

namespace Pharmacy.Domain.Entities;

public sealed class Order
{
    public Guid Id { get; set; }

    public Guid PharmacyId { get; set; }

    public Pharmacy? Pharmacy { get; set; }

    public decimal TotalPrice { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public List<Product> Products { get; set; } = null!;
}