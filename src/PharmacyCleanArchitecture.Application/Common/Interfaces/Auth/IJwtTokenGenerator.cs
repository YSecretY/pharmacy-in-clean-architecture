using PharmacyCleanArchitecture.Domain.Users.Enums;

namespace PharmacyCleanArchitecture.Application.Common.Interfaces.Auth;

public interface IJwtTokenGenerator
{
    public string GenerateToken(Guid userId, string email, UserRole userRole);

    public string GenerateEmailConfirmationToken(string email);
}