using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Identity;

namespace PharmacyCleanArchitecture.Infrastructure.Services.Identity;

public class IdentityUserAccessor(
    IHttpContextAccessor httpContextAccessor
) : IIdentityUserAccessor
{
    public Guid GetCurrentUserId()
    {
        Claim userIdClaim = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)
                            ?? throw new ArgumentNullException(nameof(ClaimTypes.NameIdentifier),
                                "Couldn't find the user id in http context claims.");
        
        return Guid.Parse(userIdClaim.Value);
    }
}