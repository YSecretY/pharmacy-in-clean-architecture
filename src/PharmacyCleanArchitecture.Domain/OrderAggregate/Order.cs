using ErrorOr;
using PharmacyCleanArchitecture.Domain.Common.Models;
using PharmacyCleanArchitecture.Domain.Common.ValueObjects.Address;
using PharmacyCleanArchitecture.Domain.Common.ValueObjects.Price;
using PharmacyCleanArchitecture.Domain.OrderAggregate.Entities;
using PharmacyCleanArchitecture.Domain.OrderAggregate.Enums;
using PharmacyCleanArchitecture.Domain.PharmacyAggregate;

namespace PharmacyCleanArchitecture.Domain.OrderAggregate;

public sealed class Order : Entity<Guid>
{
    private Order(Guid id) : base(id)
    {
    }

    public static ErrorOr<Order> Create(
        Guid id,
        Guid pharmacyId,
        decimal totalPrice,
        Address receiverAddress,
        OrderStatus orderStatus,
        List<OrderItem> orderItems
    )
    {
        List<Error> errors = new();

        ErrorOr<Price> totalPriceCreationResult = Price.Create(totalPrice);
        if (totalPriceCreationResult.IsError) errors.AddRange(totalPriceCreationResult.Errors);

        if (errors.Count is not 0) return errors;

        return new Order(id)
        {
            PharmacyId = pharmacyId,
            TotalPrice = totalPriceCreationResult.Value,
            ReceiverAddress = receiverAddress,
            Status = orderStatus,
            OrderItems = orderItems
        };
    }

    public void MakeDelivered()
    {
        UpdatedAt = DateTime.UtcNow;
        DeliveredAt = DateTime.UtcNow;
    }

    public Guid PharmacyId { get; private set; }

    public Pharmacy Pharmacy { get; private set; } = null!;

    public Price TotalPrice { get; private set; } = null!;

    public Address ReceiverAddress { get; private set; } = null!;

    public OrderStatus Status { get; private set; } = null!;

    public List<OrderItem> OrderItems { get; private set; } = null!;

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

    public DateTime DeliveredAt { get; private set; } = DateTime.MinValue;
}