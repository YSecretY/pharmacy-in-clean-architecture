using Pharmacy.Domain.User.Enums;

namespace Pharmacy.Application.Common.Interfaces.Auth;

public interface IJwtTokenGenerator
{
    public string GenerateToken(Guid userId, string firstName, UserRole userRole);
}