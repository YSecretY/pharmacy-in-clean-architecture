using FluentValidation;

namespace PharmacyCleanArchitecture.Application.Categories.Commands.Update;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(c => c.ImageUrl)
            .MaximumLength(255);
    }
}