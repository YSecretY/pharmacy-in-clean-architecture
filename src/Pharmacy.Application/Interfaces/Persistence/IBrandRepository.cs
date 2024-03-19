using ErrorOr;
using Pharmacy.Domain.Brand;

namespace Pharmacy.Application.Interfaces.Persistence;

public interface IBrandRepository
{
    public Task<ErrorOr<Brand>> AddAsync(Brand brand, CancellationToken cancellationToken);
}