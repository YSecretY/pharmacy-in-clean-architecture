using FluentValidation;

namespace Pharmacy.Application.Brands;

public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(b => b.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(b => b.ImageLogoUrl)
            .NotNull()
            .NotEmpty()
            .MaximumLength(255);
    }
}