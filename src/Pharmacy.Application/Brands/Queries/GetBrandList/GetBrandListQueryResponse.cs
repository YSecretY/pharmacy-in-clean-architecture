using Pharmacy.Domain.Brands;

namespace Pharmacy.Application.Brands.Queries.GetBrandList;

public record GetBrandListQueryResponse(List<Brand> Brands, int PageSize, int PageNumber, int MaxPages);