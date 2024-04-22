using FluentValidation;

namespace PharmacyCleanArchitecture.Application.Categories.Queries.GetCategoryList;

public class GetCategoryListQueryValidator : AbstractValidator<GetCategoryListQuery>
{
    public GetCategoryListQueryValidator()
    {
        RuleFor(q => q.PageSize)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(q => q.PageNumber)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0).WithMessage("Page size must be > 0.")
            .LessThanOrEqualTo(1000).WithMessage("Page size must be <= 1000.");
    }
}