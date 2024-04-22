namespace PharmacyCleanArchitecture.Application.Common.Interfaces.Auth;

public interface IJwtTokenValidator
{
    public Task<bool> IsValidEmailConfirmationTokenAsync(string jwtToken);
}