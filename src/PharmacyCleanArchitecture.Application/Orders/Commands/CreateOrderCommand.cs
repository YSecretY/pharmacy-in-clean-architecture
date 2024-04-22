using ErrorOr;
using MediatR;
using PharmacyCleanArchitecture.Contracts.Orders.Common.Dto;

namespace PharmacyCleanArchitecture.Application.Orders.Commands;

public record CreateOrderCommand(
    Guid PharmacyId,
    string CountryCode,
    string City,
    string PostalCode,
    string Street,
    List<OrderItemDto> OrderItems
) : IRequest<ErrorOr<Created>>;