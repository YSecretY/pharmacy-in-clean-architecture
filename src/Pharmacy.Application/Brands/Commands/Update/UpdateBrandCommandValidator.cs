using FluentValidation;

namespace Pharmacy.Application.Brands.Commands.Update;

public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
{
    public UpdateBrandCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(c => c.LogoImageUrl)
            .MaximumLength(255);
    }
}