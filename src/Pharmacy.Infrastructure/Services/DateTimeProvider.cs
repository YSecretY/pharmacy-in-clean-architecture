using Pharmacy.Application.Common.Services;

namespace Pharmacy.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}