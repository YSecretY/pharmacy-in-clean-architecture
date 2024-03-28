using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyCleanArchitecture.Application.Users.Commands.ChangeEmail;
using PharmacyCleanArchitecture.Application.Users.Commands.ChangePassword;
using PharmacyCleanArchitecture.Application.Users.Commands.EmailConfirmation;
using PharmacyCleanArchitecture.Application.Users.Commands.Login;
using PharmacyCleanArchitecture.Application.Users.Commands.MakeAdmin;
using PharmacyCleanArchitecture.Application.Users.Commands.Register;
using PharmacyCleanArchitecture.Application.Users.Commands.UpdatePhoneNumber;
using PharmacyCleanArchitecture.Contracts.Users;
using PharmacyCleanArchitecture.Domain.Users.Enums;

namespace PharmacyCleanArchitecture.Api.Controllers;

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
        ErrorOr<Updated> changePasswordResult = await mediator.Send(command);

        return changePasswordResult.Match(
            _ => Ok(),
            Problem
        );
    }

    [HttpPut("send-change-email-letter")]
    [Authorize]
    public async Task<IActionResult> SendChangeEmailLetter([FromBody] SendEmailChangeConfirmationRequest request)
    {
        SendEmailChangeConfirmationCommand command = mapper.Map<SendEmailChangeConfirmationCommand>(request);
        ErrorOr<Success> sendEmailConfirmationResult = await mediator.Send(command);

        return sendEmailConfirmationResult.Match(
            _ => Ok(),
            Problem
        );
    }

    [HttpGet("change-email")]
    public async Task<IActionResult> ChangeEmail([FromQuery] ChangeEmailRequest changeEmailRequest)
    {
        ChangeEmailCommand command = mapper.Map<ChangeEmailCommand>(changeEmailRequest);
        ErrorOr<Updated> changeEmailResult = await mediator.Send(command);

        return changeEmailResult.Match(
            _ => Ok(),
            Problem
        );
    }

    [HttpPut("make-admin")]
    [Authorize(Roles = nameof(UserRole.SuperAdmin))]
    public async Task<IActionResult> MakeAdmin([FromQuery] MakeAdminUserRequest request)
    {
        MakeAdminUserCommand command = mapper.Map<MakeAdminUserCommand>(request);
        ErrorOr<Updated> userAdminUpdateResult = await mediator.Send(command);

        return userAdminUpdateResult.Match(
            _ => Ok(),
            Problem
        );
    }

    [HttpPut("update-phone-number")]
    [Authorize]
    public async Task<IActionResult> UpdatePhoneNumber([FromQuery] UpdatePhoneNumberUserRequest request)
    {
        UpdatePhoneNumberUserCommand command = mapper.Map<UpdatePhoneNumberUserCommand>(request);
        ErrorOr<Updated> updatePhoneNumberResult = await mediator.Send(command);

        return updatePhoneNumberResult.Match(
            _ => Ok(),
            Problem
        );
    }
}