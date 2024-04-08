using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyCleanArchitecture.Application.Orders.Commands;
using PharmacyCleanArchitecture.Contracts.Orders.Create;

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
}