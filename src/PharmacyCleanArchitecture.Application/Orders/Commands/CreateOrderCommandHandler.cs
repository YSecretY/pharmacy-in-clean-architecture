using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Identity;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;
using PharmacyCleanArchitecture.Application.Common.Services;
using PharmacyCleanArchitecture.Contracts.Orders.Common.Dto;
using PharmacyCleanArchitecture.Domain.Common.ValueObjects.Address;
using PharmacyCleanArchitecture.Domain.OrderAggregate;
using PharmacyCleanArchitecture.Domain.OrderAggregate.Entities;
using PharmacyCleanArchitecture.Domain.OrderAggregate.Enums;
using PharmacyCleanArchitecture.Domain.Users.ValueObjects;
using ProductInfo = PharmacyCleanArchitecture.Domain.PharmacyAggregate.Entities.ProductInfo;

namespace PharmacyCleanArchitecture.Application.Orders.Commands;

public class CreateOrderCommandHandler(
    IPharmacyDbContext dbContext,
    IValidator<CreateOrderCommand> validator,
    IIdentityUserAccessor identityUserAccessor,
    IEmailService emailService
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
            .AsSplitQuery()
            .Include(info => info.Product)
            .ToListAsync(cancellationToken);

        List<OrderItem> orderItems = new(request.OrderItems.Count);
        foreach (OrderItemDto orderItemDto in request.OrderItems)
        {
            ProductInfo? productInfo = requestedProductsInfos.FirstOrDefault(info => info.ProductId == orderItemDto.ProductId);
            if (productInfo is null)
                return Error.NotFound(description: $"Couldn't find the product: {JsonConvert.SerializeObject(productInfo)}");

            if (productInfo.Quantity < orderItemDto.Quantity || !productInfo.IsInStock)
                return Error.Conflict(description: "Not enough products in the pharmacy.");

            productInfo.Buy(orderItemDto.Quantity);

            decimal pricePerUnit = productInfo.DiscountedPrice?.Value ?? productInfo.Product.Price.Value;

            ErrorOr<OrderItem> orderItem = OrderItem.Create(
                id: Guid.NewGuid(),
                productId: orderItemDto.ProductId,
                quantity: orderItemDto.Quantity,
                pricePerUnit: pricePerUnit,
                totalPrice: pricePerUnit * orderItemDto.Quantity
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

        decimal totalPrice = orderItems.Sum(item => item.TotalPrice.Value);

        Guid userId = identityUserAccessor.GetCurrentUserId();

        ErrorOr<Order> order = Order.Create(
            userId: userId,
            id: Guid.NewGuid(),
            pharmacyId: request.PharmacyId,
            totalPrice: totalPrice,
            receiverAddress: receiverAddress.Value,
            orderStatus: OrderStatus.Pending,
            orderItems: orderItems
        );
        if (order.IsError) return order.Errors;

        Email? userEmail = await dbContext.Users
            .Where(u => u.Id == userId)
            .Select(u => u.Email)
            .FirstOrDefaultAsync(cancellationToken);
        if (userEmail is null) return Error.Validation(description: "Email cannot be null.");

        Task emailSendingTask = Task.Run(() => emailService.SendOrderCreatedEmail(userEmail.Value), cancellationToken);

        dbContext.Orders.Add(order.Value);

        Task savingChangesTask = dbContext.SaveChangesAsync(cancellationToken);

        await Task.WhenAll(emailSendingTask, savingChangesTask);

        return Result.Created;
    }
}