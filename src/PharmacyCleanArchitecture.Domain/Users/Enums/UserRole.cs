using Ardalis.SmartEnum;

namespace PharmacyCleanArchitecture.Domain.Users.Enums;

public sealed class UserRole : SmartEnum<UserRole>
{
    public static readonly UserRole DefaultUser = new(nameof(DefaultUser), 1);
    public static readonly UserRole Admin = new(nameof(Admin), 2);
    public static readonly UserRole SuperAdmin = new(nameof(SuperAdmin), 3);

    private UserRole(string name, int value) : base(name, value)
    {
    }
}