using FluentValidation;

namespace PharmacyCleanArchitecture.Application.Pharmacies.Commands.Create;

public class CreatePharmacyCommandValidator : AbstractValidator<CreatePharmacyCommand>
{
    public CreatePharmacyCommandValidator()
    {
        RuleFor(ph => ph.CountryIsoCode)
            .NotNull()
            .NotEmpty()
            .Length(2);

        RuleFor(ph => ph.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);
    }
}