using MediatR;
using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;
using PharmacyCleanArchitecture.Domain.Products;

namespace PharmacyCleanArchitecture.Application.Pharmacies.Queries.GetProductsList;

public class GetPharmacyProductsListQueryHandler(
    IPharmacyDbContext dbContext,
    IValidator<GetPharmacyProductsListQuery> validator
) : IRequestHandler<GetPharmacyProductsListQuery, ErrorOr<GetPharmacyProductsListQueryResponse>>
{
    public async Task<ErrorOr<GetPharmacyProductsListQueryResponse>> Handle(GetPharmacyProductsListQuery request,
        CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.Errors.ConvertAll(validationFailure =>
                Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));
        }

        int productsCount = await dbContext.ProductInfos
            .Where(info => info.PharmacyId == request.PharmacyId)
            .CountAsync(cancellationToken);

        int maxPages = (int)Math.Ceiling((double)productsCount) / request.PageSize;
        if (request.PageNumber > maxPages) return Error.Validation(description: "Page number cannot be greater than max pages.");

        List<Product> products = await dbContext.ProductInfos
            .AsNoTracking()
            .AsSplitQuery()
            .Include(info => info.Product)
            .Include(info => info.Product.Brand)
            .Include(info => info.Product.Category)
            .Where(info => info.PharmacyId == request.PharmacyId)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(info => info.Product)
            .ToListAsync(cancellationToken);

        return new GetPharmacyProductsListQueryResponse
        (
            PharmacyId: request.PharmacyId,
            Products: products,
            PageSize: request.PageSize,
            PageNumber: request.PageNumber,
            MaxPages: maxPages
        );
    }
}