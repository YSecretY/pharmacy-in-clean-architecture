using ErrorOr;
using MediatR;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Z.EntityFramework.Plus;

namespace Pharmacy.Application.Brands.Commands.Remove;

public class RemoveBrandByIdCommandHandler(
        IPharmacyDbContext dbContext)
    : IRequestHandler<RemoveBrandByIdCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(RemoveBrandByIdCommand request, CancellationToken cancellationToken)
    {
        int deletedCount = await dbContext.Brands
            .Where(b => b.Id == request.Guid)
            .DeleteAsync(cancellationToken);

        if (deletedCount is 0) return Error.NotFound(description: "Brand is not found.");

        return Result.Deleted;
    }
}