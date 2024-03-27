using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Domain.Categories;

namespace Pharmacy.Application.Categories.Commands.Create;

public class CreateCategoryCommandHandler(
        IPharmacyDbContext dbContext,
        IValidator<CreateCategoryCommand> validator)
    : IRequestHandler<CreateCategoryCommand, ErrorOr<Category>>
{
    public async Task<ErrorOr<Category>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.Errors.ConvertAll(validationFailure =>
                Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));
        }

        ErrorOr<Category> categoryCreationResult = Category.Create(Guid.NewGuid(), request.Name, request.ImageUrl);
        if (categoryCreationResult.IsError) return categoryCreationResult.Errors;

        await dbContext.Categories.AddAsync(categoryCreationResult.Value, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return categoryCreationResult.Value;
    }
}