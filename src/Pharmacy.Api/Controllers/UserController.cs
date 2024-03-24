using MapsterMapper;
using MediatR;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Users.Register;
using Pharmacy.Contracts.Users;

namespace Pharmacy.Api.Controllers;

[Route("users")]
public class UserController(
    IMapper mapper,
    ISender mediator
) : ApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        RegisterUserCommand command = mapper.Map<RegisterUserCommand>(request);
        ErrorOr<Created> registerUserResult = await mediator.Send(command);

        return registerUserResult.Match(
            _ => Created(),
            Problem
        );
    }
}