using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Domain.Brand;
using Pharmacy.Domain.Common.ValueObjects.Name;

namespace Pharmacy.Application.Brands.Commands.Update;

public class UpdateBrandCommandHandler(
        IPharmacyDbContext dbContext,
        IValidator<UpdateBrandCommand> validator)
    : IRequestHandler<UpdateBrandCommand, ErrorOr<Brand>>
{
    public async Task<ErrorOr<Brand>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.Errors.ConvertAll(validationFailure =>
                Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));
        }

        Brand? brand = await dbContext.Brands.FirstOrDefaultAsync(b => b.Id == request.Guid, cancellationToken);
        if (brand is null) return Error.NotFound(description: "Brand is not found.");

        brand.Name = Name.Create(request.Name).Value;
        brand.LogoImageUrl = request.LogoImageUrl;

        return brand;
    }
}