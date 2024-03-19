using ErrorOr;
using Pharmacy.Application.Interfaces.Persistence;
using Pharmacy.Domain.Brand;
using Pharmacy.Infrastructure.Common.Persistence;

namespace Pharmacy.Infrastructure.Persistence;

public class BrandRepository(
        PharmacyDbContext dbContext)
    : IBrandRepository
{
    private readonly PharmacyDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<ErrorOr<Brand>> AddAsync(Brand brand, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(brand, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return brand;
    }
}