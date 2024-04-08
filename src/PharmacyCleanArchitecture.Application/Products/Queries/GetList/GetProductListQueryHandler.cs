using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;
using PharmacyCleanArchitecture.Domain.Products;

namespace PharmacyCleanArchitecture.Application.Products.Queries.GetList;

public class GetProductListQueryHandler(
    IPharmacyDbContext dbContext,
    IValidator<GetProductsListQuery> validator
) : IRequestHandler<GetProductsListQuery, ErrorOr<GetProductsListQueryResponse>>
{
    public async Task<ErrorOr<GetProductsListQueryResponse>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.Errors.ConvertAll(validationFailure =>
                Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));
        }

        int productsCount = await dbContext.Products.CountAsync(cancellationToken);

        int maxPages = (int)Math.Ceiling((double)productsCount / request.PageSize);
        if (request.PageNumber > maxPages) return Error.Validation(description: "Page number cannot be greater than max pages.");

        List<Product> products = await dbContext.Products
            .AsNoTracking()
            .AsSplitQuery()
            .Include(p => p.Brand)
            .Include(p => p.Category)
            .Skip(request.PageSize * (request.PageNumber - 1))
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return new GetProductsListQueryResponse
        (
            Products: products,
            PageSize: request.PageSize,
            PageNumber: request.PageNumber,
            MaxPages: maxPages
        );
    }
}