using FluentValidation;

namespace PharmacyCleanArchitecture.Application.Pharmacies.Queries.GetProductsList;

public class GetPharmacyProductsListQueryValidator : AbstractValidator<GetPharmacyProductsListQuery>
{
    public GetPharmacyProductsListQueryValidator()
    {
        RuleFor(q => q.PageNumber)
            .NotNull()
            .GreaterThan(0).WithMessage("Page number cannot be <= 0");

        RuleFor(q => q.PageSize)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0).WithMessage("Page size must be > 0.")
            .LessThanOrEqualTo(1000).WithMessage("Page size must be <= 1000.");
    }
}