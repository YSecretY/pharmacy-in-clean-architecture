using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;
using PharmacyCleanArchitecture.Domain.Brands;

namespace PharmacyCleanArchitecture.Application.Brands.Queries.GetBrandList;

public class GetBrandListQueryHandler(
        IPharmacyDbContext dbContext,
        IValidator<GetBrandListQuery> validator)
    : IRequestHandler<GetBrandListQuery, ErrorOr<GetBrandListQueryResponse>>
{
    public async Task<ErrorOr<GetBrandListQueryResponse>> Handle(GetBrandListQuery request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.Errors.ConvertAll(validationFailure =>
                Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));
        }

        int brandsCount = await dbContext.Brands
            .CountAsync(cancellationToken);

        int maxPages = (int)Math.Ceiling((double)brandsCount) / request.PageSize;
        if (request.PageNumber > maxPages) return Error.Validation(description: "Page number cannot be greater than max pages.");

        List<Brand> brands = await dbContext.Brands
            .AsNoTracking()
            .Skip(request.PageSize * (request.PageNumber - 1))
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        GetBrandListQueryResponse response = new(
            Brands: brands,
            PageSize: request.PageSize,
            PageNumber: request.PageNumber,
            MaxPages: maxPages
        );

        return response;
    }
}