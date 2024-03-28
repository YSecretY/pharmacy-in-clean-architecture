namespace PharmacyCleanArchitecture.Infrastructure.Auth;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";

    public string Secret { get; init; } = null!;

    public string Issuer { get; init; } = null!;

    public string Audience { get; init; } = null!;

    public string EmailAudience { get; init; } = null!;

    public int ExpirationInMinutes { get; init; }
}