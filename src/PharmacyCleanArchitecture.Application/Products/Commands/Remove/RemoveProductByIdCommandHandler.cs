using ErrorOr;
using MediatR;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;
using Z.EntityFramework.Plus;

namespace PharmacyCleanArchitecture.Application.Products.Commands.Remove;

public class RemoveProductByIdCommandHandler(
    IPharmacyDbContext dbContext
) : IRequestHandler<RemoveProductByIdCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(RemoveProductByIdCommand request, CancellationToken cancellationToken)
    {
        int deletedCount = await dbContext.Products
            .Where(p => p.Id == request.Id)
            .DeleteAsync(cancellationToken);

        if (deletedCount is 0) return Error.NotFound("Product with the given id is not found.");

        return Result.Deleted;
    }
}