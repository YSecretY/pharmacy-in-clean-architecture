namespace PharmacyCleanArchitecture.Application.Common.Services;

public interface IPasswordHasher
{
    public string HashPassword(string password);

    public bool Verify(string password, string passwordHash);
}