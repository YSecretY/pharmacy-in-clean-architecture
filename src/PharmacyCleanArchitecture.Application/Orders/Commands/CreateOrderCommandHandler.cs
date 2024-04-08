using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;
using PharmacyCleanArchitecture.Contracts.Orders.Common.Dto;
using PharmacyCleanArchitecture.Domain.Common.ValueObjects.Address;
using PharmacyCleanArchitecture.Domain.OrderAggregate;
using PharmacyCleanArchitecture.Domain.OrderAggregate.Entities;
using PharmacyCleanArchitecture.Domain.OrderAggregate.Enums;
using ProductInfo = PharmacyCleanArchitecture.Domain.PharmacyAggregate.Entities.ProductInfo;

namespace PharmacyCleanArchitecture.Application.Orders.Commands;

public class CreateOrderCommandHandler(
    IPharmacyDbContext dbContext,
    IValidator<CreateOrderCommand> validator
) : IRequestHandler<CreateOrderCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.Errors.ConvertAll(validationFailure =>
                Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));
        }

        List<Guid> requestedProductsIds = request.OrderItems.Select(item => item.ProductId).ToList();

        List<ProductInfo> requestedProductsInfos = await dbContext.ProductInfos
            .Where(info => info.PharmacyId == request.PharmacyId && requestedProductsIds.Contains(info.ProductId))
            .ToListAsync(cancellationToken);

        foreach (OrderItemDto orderItemDto in request.OrderItems)
        {
            if (orderItemDto.TotalPrice != orderItemDto.PricePerUnit * orderItemDto.Quantity)
                return Error.Validation(description: "Wrong total price.");

            ProductInfo? productInfo = requestedProductsInfos.FirstOrDefault(info => info.ProductId == orderItemDto.ProductId);
            if (productInfo is null)
                return Error.NotFound(description: $"Couldn't find the product: {JsonConvert.SerializeObject(productInfo)}");

            if (productInfo.Quantity < orderItemDto.Quantity || !productInfo.IsInStock)
                return Error.Conflict(description: "Not enough products in the pharmacy.");

            productInfo.Buy(orderItemDto.Quantity);
        }

        List<OrderItem> orderItems = new(request.OrderItems.Count);
        foreach (OrderItemDto orderItemDto in request.OrderItems)
        {
            ErrorOr<OrderItem> orderItem = OrderItem.Create(
                id: Guid.NewGuid(),
                productId: orderItemDto.ProductId,
                quantity: orderItemDto.Quantity,
                pricePerUnit: orderItemDto.PricePerUnit,
                totalPrice: orderItemDto.TotalPrice
            );
            if (orderItem.IsError) return orderItem.Errors;

            orderItems.Add(orderItem.Value);
        }

        ErrorOr<Address> receiverAddress = Address.Create(
            countryIsoCode: request.CountryCode,
            street: request.Street,
            city: request.City,
            postalCode: request.PostalCode
        );
        if (receiverAddress.IsError) return receiverAddress.Errors;

        decimal totalPrice = request.OrderItems.Sum(item => item.TotalPrice);

        ErrorOr<Order> order = Order.Create(
            id: Guid.NewGuid(),
            pharmacyId: request.PharmacyId,
            totalPrice: totalPrice,
            receiverAddress: receiverAddress.Value,
            orderStatus: OrderStatus.Pending,
            orderItems: orderItems
        );
        if (order.IsError) return order.Errors;

        dbContext.Orders.Add(order.Value);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Created;
    }
}