using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Domain.Brand;

namespace Pharmacy.Application.Brands.Commands.RemoveBrand;

public class RemoveBrandByIdCommandHandler(
        IPharmacyDbContext dbContext)
    : IRequestHandler<RemoveBrandByIdCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(RemoveBrandByIdCommand request, CancellationToken cancellationToken)
    {
        Brand? brand = await dbContext.Brands
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == request.Guid, cancellationToken);
        if (brand is null) return Error.NotFound(description: "Brand is not found.");

        dbContext.Brands.Remove(brand);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}