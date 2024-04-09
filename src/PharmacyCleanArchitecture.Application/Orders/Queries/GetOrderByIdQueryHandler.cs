using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;
using PharmacyCleanArchitecture.Domain.OrderAggregate;

namespace PharmacyCleanArchitecture.Application.Orders.Queries;

public class GetOrderByIdQueryHandler(
    IPharmacyDbContext dbContext
) : IRequestHandler<GetOrderByIdQuery, ErrorOr<Order>>
{
    public async Task<ErrorOr<Order>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        Order? order = await dbContext.Orders
            .AsNoTracking()
            .AsSplitQuery()
            .Include(order => order.OrderItems)
            .FirstOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken);
        if (order is null) return Error.NotFound(description: "Order with given id is not found.");

        return order;
    }
}