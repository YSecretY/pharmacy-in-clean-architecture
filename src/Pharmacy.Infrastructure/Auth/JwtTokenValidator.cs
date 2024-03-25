using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pharmacy.Application.Common.Interfaces.Auth;

namespace Pharmacy.Infrastructure.Auth;

public class JwtTokenValidator(
    IOptions<JwtSettings> jwtOptions
) : IJwtTokenValidator
{
    private readonly JwtSettings _jwtSettings = jwtOptions.Value;

    public async Task<bool> IsValidEmailConfirmationTokenAsync(string jwtToken)
    {
        TokenValidationParameters validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _jwtSettings.Issuer,
            ValidAudience = _jwtSettings.EmailAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret).ToArray()),
        };

        JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
        TokenValidationResult tokenValidationResult = await jwtSecurityTokenHandler.ValidateTokenAsync(jwtToken, validationParameters);

        return tokenValidationResult.IsValid;
    }
}