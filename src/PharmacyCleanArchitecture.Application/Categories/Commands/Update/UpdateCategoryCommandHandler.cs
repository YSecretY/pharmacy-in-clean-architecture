using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;
using PharmacyCleanArchitecture.Domain.Categories;
using PharmacyCleanArchitecture.Domain.Common.ValueObjects.Name;

namespace PharmacyCleanArchitecture.Application.Categories.Commands.Update;

public class UpdateCategoryCommandHandler(
        IPharmacyDbContext dbContext,
        IValidator<UpdateCategoryCommand> validator)
    : IRequestHandler<UpdateCategoryCommand, ErrorOr<Category>>
{
    public async Task<ErrorOr<Category>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.Errors.ConvertAll(validationFailure =>
                Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));
        }

        Category? category = await dbContext.Categories
            .FirstOrDefaultAsync(c => c.Id == request.Guid, cancellationToken);
        if (category is null) return Error.NotFound("Category is not found.");

        category.Name = Name.Create(request.Name).Value;
        category.ImageUrl = request.ImageUrl;

        await dbContext.SaveChangesAsync(cancellationToken);

        return category;
    }
}