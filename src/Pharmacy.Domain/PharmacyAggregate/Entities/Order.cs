using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.Common.ValueObjects.Address;
using Pharmacy.Domain.Common.ValueObjects.Price;
using Pharmacy.Domain.OrderItems;
using Pharmacy.Domain.PharmacyAggregate.Enums;
using ErrorOr;

namespace Pharmacy.Domain.PharmacyAggregate.Entities;

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

    public Guid PharmacyId { get; private set; }

    public Pharmacy Pharmacy { get; private set; } = null!;

    public Price TotalPrice { get; private set; } = null!;

    public Address ReceiverAddress { get; private set; } = null!;

    public OrderStatus Status { get; private set; } = null!;

    public List<OrderItem> OrderItems { get; private set; } = null!;

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
}