using PharmacyCleanArchitecture.Contracts.Orders.Common.Dto;

namespace PharmacyCleanArchitecture.Contracts.Orders.Create;

public record CreateOrderRequest(
    Guid PharmacyId,
    string CountryCode,
    string City,
    string PostalCode,
    string Street,
    List<OrderItemDto> OrderItems
);