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
            .GreaterThan(0);
    }
}