using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Domain.Category;

namespace Pharmacy.Application.Categories.Commands.Queries.GetCategoryList;

public class GetCategoryListQueryHandler(
        IPharmacyDbContext dbContext,
        IValidator<GetCategoryListQuery> validator)
    : IRequestHandler<GetCategoryListQuery, ErrorOr<GetCategoryListQueryResponse>>
{
    public async Task<ErrorOr<GetCategoryListQueryResponse>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.Errors.ConvertAll(validationFailure =>
                Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));
        }

        int categoriesCount = await dbContext.Categories
            .AsNoTracking()
            .CountAsync(cancellationToken);

        int maxPages = (int)Math.Ceiling((double)categoriesCount / request.PageSize);
        if (request.PageNumber > maxPages) return Error.Validation(description: "Page number cannot be greater than max pages.");

        List<Category> categories = await dbContext.Categories
            .AsNoTracking()
            .Skip(request.PageSize * (request.PageNumber - 1))
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return new GetCategoryListQueryResponse(
            Categories: categories,
            PageSize: request.PageSize,
            PageNumber: request.PageNumber,
            MaxPages: maxPages
        );
    }
}