using FluentValidation;

namespace PharmacyCleanArchitecture.Application.Orders.Commands;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(c => c.CountryCode)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(3);

        RuleFor(c => c.OrderItems)
            .Must(items => items.Count > 0);

        RuleFor(c => c.PostalCode)
            .NotNull()
            .NotEmpty();

        RuleFor(c => c.Street)
            .NotNull()
            .NotEmpty();

        RuleFor(c => c.City)
            .NotNull()
            .NotEmpty();
    }
}