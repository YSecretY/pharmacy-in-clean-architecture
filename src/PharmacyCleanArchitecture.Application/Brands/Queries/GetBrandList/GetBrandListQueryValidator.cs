using FluentValidation;

namespace PharmacyCleanArchitecture.Application.Brands.Queries.GetBrandList;

public class GetBrandListQueryValidator : AbstractValidator<GetBrandListQuery>
{
    public GetBrandListQueryValidator()
    {
        RuleFor(q => q.PageNumber)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0).WithMessage("Page number must be > 0.");

        RuleFor(q => q.PageSize)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0).WithMessage("Page size must be > 0.")
            .LessThanOrEqualTo(1000).WithMessage("Page size must be <= 1000.");
    }
}