namespace Pharmacy.Application.Common.Interfaces.Identity;

public interface IIdentityUserAccessor
{
    public Guid GetCurrentUserId();
}