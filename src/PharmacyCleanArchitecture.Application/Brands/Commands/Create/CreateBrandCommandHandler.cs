using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;
using PharmacyCleanArchitecture.Domain.Brands;

namespace PharmacyCleanArchitecture.Application.Brands.Commands.Create;

public class CreateBrandCommandHandler(
    IPharmacyDbContext dbContext,
    IValidator<CreateBrandCommand> validator
) : IRequestHandler<CreateBrandCommand, ErrorOr<Brand>>
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