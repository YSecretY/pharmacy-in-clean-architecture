using Pharmacy.Contracts.Brands.Common;

namespace Pharmacy.Contracts.Brands.Get;

public record GetBrandListResponse(List<BrandResponse> Brands, int PageSize, int PageNumber, int MaxPages);