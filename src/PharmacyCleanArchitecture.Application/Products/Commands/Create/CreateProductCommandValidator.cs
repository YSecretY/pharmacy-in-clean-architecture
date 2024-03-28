using FluentValidation;

namespace PharmacyCleanArchitecture.Application.Products.Commands.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(100);

        RuleFor(p => p.Description)
            .MinimumLength(50)
            .MaximumLength(500);

        RuleFor(p => p.ImageUrl)
            .MaximumLength(255);

        RuleFor(p => p.Sku)
            .MinimumLength(3)
            .MaximumLength(20);

        RuleFor(p => p.Price)
            .NotNull()
            .GreaterThanOrEqualTo(0);
    }
}