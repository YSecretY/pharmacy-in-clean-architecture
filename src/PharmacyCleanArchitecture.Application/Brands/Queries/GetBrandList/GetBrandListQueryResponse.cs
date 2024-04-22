using PharmacyCleanArchitecture.Domain.Brands;

namespace PharmacyCleanArchitecture.Application.Brands.Queries.GetBrandList;

public record GetBrandListQueryResponse(List<Brand> Brands, int PageSize, int PageNumber, int MaxPages);