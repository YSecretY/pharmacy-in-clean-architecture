using PharmacyCleanArchitecture.Application.Common.Services;

namespace PharmacyCleanArchitecture.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}