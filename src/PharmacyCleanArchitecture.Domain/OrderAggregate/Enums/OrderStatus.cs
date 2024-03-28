using Ardalis.SmartEnum;

namespace PharmacyCleanArchitecture.Domain.OrderAggregate.Enums;

public sealed class OrderStatus : SmartEnum<OrderStatus>
{
    public static readonly OrderStatus Pending = new(nameof(Pending), 1);
    public static readonly OrderStatus Processing = new(nameof(Processing), 2);
    public static readonly OrderStatus Shipped = new(nameof(Shipped), 3);
    public static readonly OrderStatus Delivered = new(nameof(Delivered), 4);
    public static readonly OrderStatus Canceled = new(nameof(Canceled), 5);

    private OrderStatus(string name, int value) : base(name, value)
    {
    }
}