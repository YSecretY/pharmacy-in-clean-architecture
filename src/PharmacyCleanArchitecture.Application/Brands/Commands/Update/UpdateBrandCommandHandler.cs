using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;
using PharmacyCleanArchitecture.Domain.Brands;
using PharmacyCleanArchitecture.Domain.Common.ValueObjects.Name;

namespace PharmacyCleanArchitecture.Application.Brands.Commands.Update;

public class UpdateBrandCommandHandler(
    IPharmacyDbContext dbContext,
    IValidator<UpdateBrandCommand> validator)
    : IRequestHandler<UpdateBrandCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.Errors.ConvertAll(validationFailure =>
                Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));
        }

        int updatedCount = await dbContext.Brands
            .Where(b => b.Id == request.Guid)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(b => b.Name, Name.Create(request.Name).Value)
                .SetProperty(b => b.LogoImageUrl, request.LogoImageUrl), cancellationToken);

        return updatedCount == 1 ? Result.Updated : Error.NotFound("The brand with given id was not found.");
    }
}