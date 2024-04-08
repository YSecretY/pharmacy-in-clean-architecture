using ErrorOr;
using MediatR;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;
using Z.EntityFramework.Plus;

namespace PharmacyCleanArchitecture.Application.Pharmacies.Commands.RemoveProducts;

public class RemovePharmacyProductByIdCommandHandler(
    IPharmacyDbContext dbContext
) : IRequestHandler<RemovePharmacyProductByIdCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(RemovePharmacyProductByIdCommand request, CancellationToken cancellationToken)
    {
        int deletedCount = await dbContext.ProductInfos
            .Where(info => info.PharmacyId == request.PharmacyId && info.ProductId == request.ProductId)
            .DeleteAsync(cancellationToken);

        if (deletedCount is 0) return Error.NotFound(description: "Product is not found.");

        return Result.Deleted;
    }
}