using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Domain.Product;

namespace Pharmacy.Application.Products.Create;

public class CreateProductCommandHandler(
    IPharmacyDbContext dbContext,
    IValidator<CreateProductCommand> validator
) : IRequestHandler<CreateProductCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.Errors.ConvertAll(validationFailure =>
                Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));
        }

        ErrorOr<Product> productCreationResult = Product.Create(
            id: Guid.NewGuid(),
            name: request.Name,
            sku: request.Sku,
            imageUrl: request.ImageUrl,
            brandId: request.BrandId,
            categoryId: request.CategoryId,
            price: request.Price,
            description: request.Description
        );
        if (productCreationResult.IsError) return productCreationResult.Errors;

        await dbContext.Products.AddAsync(productCreationResult.Value, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Created;
    }
}