using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;
using PharmacyCleanArchitecture.Domain.PharmacyAggregate.Entities;

namespace PharmacyCleanArchitecture.Application.Pharmacies.Commands.AddProducts.Existing;

public class AddExistingProductToPharmacyCommandHandler(
    IPharmacyDbContext dbContext
) : IRequestHandler<AddExistingProductToPharmacyCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(AddExistingProductToPharmacyCommand request, CancellationToken cancellationToken)
    {
        if (!await dbContext.Pharmacies.AnyAsync(ph => ph.Id == request.PharmacyId, cancellationToken))
            return Error.NotFound(description: "Pharmacy with the given id is not found.");

        if (!await dbContext.Products.AnyAsync(ph => ph.Id == request.ProductId, cancellationToken))
            return Error.NotFound(description: "Product with the given id is not found.");

        ErrorOr<ProductInfo> productInfoCreationResult = ProductInfo.Create(
            id: Guid.NewGuid(),
            pharmacyId: request.PharmacyId,
            productId: request.ProductId,
            quantity: request.Quantity,
            isInStock: request.IsInStock,
            discountedPrice: request.DiscountedPrice
        );
        if (productInfoCreationResult.IsError) return productInfoCreationResult.Errors;

        await dbContext.ProductInfos.AddAsync(productInfoCreationResult.Value, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}