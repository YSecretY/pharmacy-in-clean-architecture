using MediatR;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using PharmacyCleanArchitecture.Domain.PharmacyAggregate.Entities;
using PharmacyCleanArchitecture.Domain.Products;

namespace PharmacyCleanArchitecture.Application.Pharmacies.Queries.GetProductById;

public class GetPharmacyProductByIdQueryHandler(
    IPharmacyDbContext dbContext
) : IRequestHandler<GetPharmacyProductByIdQuery, ErrorOr<GetPharmacyProductByIdQueryResponse>>
{
    public async Task<ErrorOr<GetPharmacyProductByIdQueryResponse>> Handle(GetPharmacyProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        ProductInfo? productInfo = await dbContext.ProductInfos
            .AsNoTracking()
            .FirstOrDefaultAsync(pi =>
                    pi.ProductId == request.ProductId && pi.PharmacyId == request.PharmacyId, cancellationToken
            );
        if (productInfo is null) return Error.NotFound(description: "Product with the given id is not found in given pharmacy.");

        Product? product = await dbContext.Products
            .AsNoTracking()
            .AsSplitQuery()
            .Include(p => p.Brand)
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == request.ProductId, cancellationToken);
        if (product is null) return Error.NotFound(description: "Product with the given id is not found.");

        return new GetPharmacyProductByIdQueryResponse(
            ProductId: product.Id,
            Name: product.Name.Value,
            Sku: product.Sku?.Value,
            ImageUrl: product.ImageUrl,
            Brand: product.Brand,
            Category: product.Category,
            Price: product.Price.Value,
            Description: product.Description,
            Quantity: productInfo.Quantity,
            IsInStock: productInfo.IsInStock,
            DiscountedPrice: productInfo.DiscountedPrice?.Value
        );
    }
}