using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyCleanArchitecture.Application.Orders.Commands;
using PharmacyCleanArchitecture.Application.Orders.Queries;
using PharmacyCleanArchitecture.Contracts.Orders.Common;
using PharmacyCleanArchitecture.Contracts.Orders.Create;
using PharmacyCleanArchitecture.Contracts.Orders.Get;
using PharmacyCleanArchitecture.Domain.OrderAggregate;

namespace PharmacyCleanArchitecture.Api.Controllers;

[Route("orders")]
[Authorize]
public class OrderController(
    ISender mediator,
    IMapper mapper
) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
    {
        CreateOrderCommand command = mapper.Map<CreateOrderCommand>(request);
        ErrorOr<Created> orderCreationResult = await mediator.Send(command);

        return orderCreationResult.Match(
            _ => Ok(),
            Problem
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetOrderById([FromQuery] GetOrderByIdRequest request)
    {
        GetOrderByIdQuery query = mapper.Map<GetOrderByIdQuery>(request);
        ErrorOr<Order> getOrderResult = await mediator.Send(query);

        return getOrderResult.Match(
            order => Ok(mapper.Map<OrderResponse>(order)),
            Problem
        );
    }
}