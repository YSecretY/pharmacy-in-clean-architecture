using PharmacyCleanArchitecture.Contracts.Orders.Common.Dto;

namespace PharmacyCleanArchitecture.Contracts.Orders.Common;

public record OrderResponse(
    Guid OrderId,
    Guid PharmacyId,
    string CountryCode,
    string City,
    string PostalCode,
    string Street,
    List<OrderItemDto> OrderItems
);