using MediatR;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Common.Interfaces.Auth;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Application.Common.Services;
using Pharmacy.Domain.Users.ValueObjects;

namespace Pharmacy.Application.Users.Login;

public class LoginUserCommandHandler(
        IPharmacyDbContext dbContext,
        IJwtTokenGenerator jwtTokenGenerator,
        IPasswordHasher passwordHasher)
    : IRequestHandler<LoginUserCommand, ErrorOr<string>>
{
    public async Task<ErrorOr<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        ErrorOr<Email> inputEmail = Email.Create(request.Email);
        if (inputEmail.IsError) return inputEmail.Errors;

        var tokenCredentials = await dbContext.Users
            .Where(u => u.Email == inputEmail.Value)
            .Select(u => new
            {
                u.Id,
                u.Email,
                u.PasswordHash,
                u.EmailConfirmed,
                u.Role
            })
            .FirstOrDefaultAsync(cancellationToken);
        if (tokenCredentials is null) return Error.NotFound(description: "Couldn't find user with the given email.");

        if (!passwordHasher.Verify(request.Password, tokenCredentials.PasswordHash.Value))
            return Error.Unauthorized(description: "Invalid credentials.");

        if (!tokenCredentials.EmailConfirmed)
            return Error.Unauthorized(description: "Email must be confirmed.");

        return jwtTokenGenerator.GenerateToken(tokenCredentials.Id, tokenCredentials.Email.Value, tokenCredentials.Role);
    }
}