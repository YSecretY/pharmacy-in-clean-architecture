using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Domain.Brand;

namespace Pharmacy.Application.Brands.Commands.CreateBrand;

public class CreateBrandCommandHandler(
        IPharmacyDbContext dbContext,
        IValidator<CreateBrandCommand> validator)
    : IRequestHandler<CreateBrandCommand, ErrorOr<Brand>>
{
    public async Task<ErrorOr<Brand>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.Errors.ConvertAll(validationFailure =>
                Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));
        }

        ErrorOr<Brand> brandCreationResult = Brand.Create(Guid.NewGuid(), request.Name, request.ImageLogoUrl);
        if (brandCreationResult.IsError) return brandCreationResult.Errors;

        await dbContext.Brands.AddAsync(brandCreationResult.Value, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return brandCreationResult.Value;
    }
}