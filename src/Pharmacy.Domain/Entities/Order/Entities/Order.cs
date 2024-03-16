using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.Entities.Enums;

namespace Pharmacy.Domain.Entities.Order.Entities;

public sealed class Order : Entity
{
    public Order(Guid id, Guid pharmacyId, decimal totalPrice, OrderStatus status, List<Product.Entities.Product> products) : base(id)
    {
        PharmacyId = pharmacyId;
        TotalPrice = totalPrice;
        Status = status;
        Products = products;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public Guid PharmacyId { get; set; }

    public Pharmacy.Entities.Pharmacy? Pharmacy { get; set; }

    public decimal TotalPrice { get; set; }

    public OrderStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public List<Product.Entities.Product> Products { get; set; }
}