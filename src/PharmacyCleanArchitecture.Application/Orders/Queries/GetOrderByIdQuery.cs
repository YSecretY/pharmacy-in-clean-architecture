using MediatR;
using ErrorOr;
using PharmacyCleanArchitecture.Domain.OrderAggregate;

namespace PharmacyCleanArchitecture.Application.Orders.Queries;

public record GetOrderByIdQuery(Guid OrderId) : IRequest<ErrorOr<Order>>;