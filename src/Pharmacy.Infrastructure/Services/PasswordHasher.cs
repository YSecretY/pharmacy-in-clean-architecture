using Pharmacy.Application.Common.Services;

namespace Pharmacy.Infrastructure.Services;

public class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);

    public bool Verify(string password, string passwordHash)
        => BCrypt.Net.BCrypt.Verify(password, passwordHash);
}