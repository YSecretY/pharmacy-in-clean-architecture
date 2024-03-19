using MediatR;
using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Domain.Brand;

namespace Pharmacy.Application.Brands.Queries.GetBrandList;

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

        List<Brand> brands = await dbContext.Brands
            .AsNoTracking()
            .Skip(request.PageSize * (request.PageNumber - 1))
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        int brandsCount = await dbContext.Brands
            .AsNoTracking()
            .CountAsync(cancellationToken);

        GetBrandListQueryResponse response = new(
            Brands: brands,
            PageSize: request.PageSize,
            PageNumber: request.PageNumber,
            MaxPages: (int)Math.Ceiling((double)brandsCount) / request.PageSize
        );

        return response;
    }
}