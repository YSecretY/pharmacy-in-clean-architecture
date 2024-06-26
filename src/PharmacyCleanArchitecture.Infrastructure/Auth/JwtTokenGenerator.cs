using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Auth;
using PharmacyCleanArchitecture.Application.Common.Services;
using PharmacyCleanArchitecture.Domain.Users.Enums;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace PharmacyCleanArchitecture.Infrastructure.Auth;

public class JwtTokenGenerator(
    IDateTimeProvider dateTimeProvider,
    IOptions<JwtSettings> jwtOptions
) : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings = jwtOptions.Value;

    public string GenerateToken(Guid userId, string email, UserRole userRole)
    {
        SigningCredentials signingCredentials = new
        (
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret).ToArray()),
            SecurityAlgorithms.HmacSha256
        );

        IEnumerable<Claim> claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(ClaimTypes.Role, userRole.Name),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        JwtSecurityToken securityToken = new
        (
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    public string GenerateEmailConfirmationToken(string email)
    {
        SigningCredentials signingCredentials = new(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret).ToArray()),
            SecurityAlgorithms.HmacSha256
        );

        IEnumerable<Claim> claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        JwtSecurityToken securityToken = new
        (
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.EmailAudience,
            expires: dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}