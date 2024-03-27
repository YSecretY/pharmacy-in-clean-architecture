using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Domain.Product;

namespace Pharmacy.Application.Products.Queries.GetById;

public class GetProductByIdCommandHandler(
    IPharmacyDbContext dbContext
) : IRequestHandler<GetProductByIdCommand, ErrorOr<Product>>
{
    public async Task<ErrorOr<Product>> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
    {
        Product? product = await dbContext.Products
            .AsNoTracking()
            .AsSplitQuery()
            .Include(p => p.Brand)
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (product is null) return Error.NotFound("Product with the given id is not found.");

        return product;
    }
}