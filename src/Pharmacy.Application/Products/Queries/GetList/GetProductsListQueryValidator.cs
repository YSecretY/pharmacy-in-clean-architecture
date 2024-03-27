using FluentValidation;

namespace Pharmacy.Application.Products.Queries.GetList;

public class GetProductsListQueryValidator : AbstractValidator<GetProductsListQuery>
{
    public GetProductsListQueryValidator()
    {
        RuleFor(q => q.PageNumber)
            .NotNull()
            .GreaterThan(0);

        RuleFor(q => q.PageSize)
            .NotNull()
            .GreaterThan(0);
    }
}