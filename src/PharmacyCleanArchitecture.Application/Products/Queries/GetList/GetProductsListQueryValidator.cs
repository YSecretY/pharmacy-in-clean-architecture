using FluentValidation;

namespace PharmacyCleanArchitecture.Application.Products.Queries.GetList;

public class GetProductsListQueryValidator : AbstractValidator<GetProductsListQuery>
{
    public GetProductsListQueryValidator()
    {
        RuleFor(q => q.PageNumber)
            .NotNull()
            .GreaterThan(0);

        RuleFor(q => q.PageSize)
            .NotNull()
            .GreaterThan(0).WithMessage("Page size must be > 0.")
            .LessThanOrEqualTo(1000).WithMessage("Page size must be <= 1000.");
    }
}