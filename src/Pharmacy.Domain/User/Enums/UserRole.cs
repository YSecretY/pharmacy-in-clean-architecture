using Ardalis.SmartEnum;

namespace Pharmacy.Domain.User.Enums;

public sealed class UserRole : SmartEnum<UserRole>
{
    public static readonly UserRole DefaultUser = new(nameof(DefaultUser), 1);
    public static readonly UserRole Admin = new(nameof(Admin), 2);

    private UserRole(string name, int value) : base(name, value)
    {
    }
}