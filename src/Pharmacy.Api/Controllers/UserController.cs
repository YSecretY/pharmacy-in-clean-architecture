using MapsterMapper;
using MediatR;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Common.Interfaces.Auth;
using Pharmacy.Application.Users.ChangePassword;
using Pharmacy.Application.Users.EmailConfirmation;
using Pharmacy.Application.Users.Login;
using Pharmacy.Application.Users.Register;
using Pharmacy.Contracts.Users;

namespace Pharmacy.Api.Controllers;

[Route("users")]
public class UserController(
    IMapper mapper,
    ISender mediator,
    IJwtTokenGenerator jwtTokenGenerator,
    IJwtTokenValidator jwtTokenValidator
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

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
    {
        LoginUserCommand command = mapper.Map<LoginUserCommand>(request);
        ErrorOr<string> loginUserResult = await mediator.Send(command);

        return loginUserResult.Match(Ok, Problem);
    }

    [HttpGet("confirm-email")]
    public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailRequest request)
    {
        ConfirmEmailCommand command = mapper.Map<ConfirmEmailCommand>(request);
        ErrorOr<Success> emailConfirmationResult = await mediator.Send(command);

        return emailConfirmationResult.Match(
            _ => Ok(),
            Problem
        );
    }

    [HttpPut("change-password")]
    [Authorize]
    public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordRequest request)
    {
        ChangePasswordCommand command = mapper.Map<ChangePasswordCommand>(request);
        ErrorOr<Success> changePasswordResult = await mediator.Send(command);

        return changePasswordResult.Match(
            _ => Ok(),
            Problem
        );
    }
}