namespace PharmacyCleanArchitecture.Contracts.Orders.Common.Dto;

public record OrderItemDto(
    Guid ProductId,
    int Quantity
);