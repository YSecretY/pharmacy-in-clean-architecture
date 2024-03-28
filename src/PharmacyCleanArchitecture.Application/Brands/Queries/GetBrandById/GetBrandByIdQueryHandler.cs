using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;
using PharmacyCleanArchitecture.Domain.Brands;

namespace PharmacyCleanArchitecture.Application.Brands.Queries.GetBrandById;

public class GetBrandByIdQueryHandler
    (IPharmacyDbContext dbContext)
    : IRequestHandler<GetBrandByIdQuery, ErrorOr<Brand>>
{
    public async Task<ErrorOr<Brand>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
    {
        Brand? brand = await dbContext.Brands
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == request.Guid, cancellationToken);

        if (brand is null) return Error.NotFound();

        return brand;
    }
}