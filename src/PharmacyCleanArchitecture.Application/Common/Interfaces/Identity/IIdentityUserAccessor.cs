namespace PharmacyCleanArchitecture.Application.Common.Interfaces.Identity;

public interface IIdentityUserAccessor
{
    public Guid GetCurrentUserId();
}