using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;
using PharmacyCleanArchitecture.Application.Products.Commands.Create;
using PharmacyCleanArchitecture.Domain.PharmacyAggregate.Entities;
using PharmacyCleanArchitecture.Domain.Products;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace PharmacyCleanArchitecture.Application.Pharmacies.Commands.AddProducts;

public class AddNewProductToPharmacyCommandHandler(
    IPharmacyDbContext dbContext,
    IValidator<CreateProductCommand> productValidator
) : IRequestHandler<AddNewProductToPharmacyCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(AddNewProductToPharmacyCommand request, CancellationToken cancellationToken)
    {
        if (!await dbContext.Pharmacies.AnyAsync(ph => ph.Id == request.PharmacyId, cancellationToken))
            return Error.NotFound(description: "Pharmacy with the given id is not found.");

        ValidationResult validationResult = await productValidator.ValidateAsync(request.CreateProductCommand, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.Errors.ConvertAll(validationFailure =>
                Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));
        }

        ErrorOr<Product> productCreationResult = Product.Create(
            id: Guid.NewGuid(),
            name: request.CreateProductCommand.Name,
            sku: request.CreateProductCommand.Sku,
            imageUrl: request.CreateProductCommand.ImageUrl,
            brandId: request.CreateProductCommand.BrandId,
            categoryId: request.CreateProductCommand.CategoryId,
            price: request.CreateProductCommand.Price,
            description: request.CreateProductCommand.Description
        );
        if (productCreationResult.IsError) return productCreationResult.Errors;

        await dbContext.Products.AddAsync(productCreationResult.Value, cancellationToken);

        ErrorOr<ProductInfo> productInfoCreationResult = ProductInfo.Create(
            id: Guid.NewGuid(),
            pharmacyId: request.PharmacyId,
            productId: productCreationResult.Value.Id,
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