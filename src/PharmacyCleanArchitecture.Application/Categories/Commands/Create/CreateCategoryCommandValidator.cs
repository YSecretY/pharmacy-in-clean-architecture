using FluentValidation;

namespace PharmacyCleanArchitecture.Application.Categories.Commands.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(c => c.ImageUrl)
            .MaximumLength(255);
    }
}