using ErrorOr;
using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.Common.ValueObjects.Price;
using Pharmacy.Domain.Products;

namespace Pharmacy.Domain.OrderItems;

public class OrderItem : Entity<Guid>
{
    private OrderItem(Guid id, Guid productId, int quantity, Price pricePerUnit, Price totalPrice) : base(id)
    {
        ProductId = productId;
        Quantity = quantity;
        PricePerUnit = pricePerUnit;
        TotalPrice = totalPrice;
    }

    public static ErrorOr<OrderItem> Create(Guid id, Guid productId, int quantity, decimal pricePerUnit, decimal totalPrice)
    {
        List<Error> errors = new();

        if (quantity <= 0) errors.Add(Error.Validation("Quantity.Negative", "Quantity cannot be negative."));

        ErrorOr<Price> pricePerUnitCreationResult = Price.Create(pricePerUnit);
        if (pricePerUnitCreationResult.IsError) errors.AddRange(pricePerUnitCreationResult.Errors);

        ErrorOr<Price> totalPriceCreationResult = Price.Create(totalPrice);
        if (totalPriceCreationResult.IsError) errors.AddRange(totalPriceCreationResult.Errors);

        if ((decimal)totalPriceCreationResult.Value < (decimal)pricePerUnitCreationResult.Value)
            errors.Add(Error.Validation("TotalPriceLessThanPricePerUnit", "Total price cannot be less than price per unit."));

        if (errors.Count is not 0) return errors;

        return new OrderItem(
            id: id,
            productId: productId,
            quantity: quantity,
            pricePerUnit: pricePerUnitCreationResult.Value,
            totalPrice: totalPriceCreationResult.Value
        );
    }
    
    public Guid ProductId { get; private set; }

    public Product Product { get; private set; } = null!;

    public int Quantity { get; private set; }

    public Price PricePerUnit { get; private set; }

    public Price TotalPrice { get; private set; }
}