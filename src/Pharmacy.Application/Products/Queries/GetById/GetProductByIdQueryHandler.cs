using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Domain.Products;

namespace Pharmacy.Application.Products.Queries.GetById;

public class GetProductByIdQueryHandler(
    IPharmacyDbContext dbContext
) : IRequestHandler<GetProductByIdQuery, ErrorOr<Product>>
{
    public async Task<ErrorOr<Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
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