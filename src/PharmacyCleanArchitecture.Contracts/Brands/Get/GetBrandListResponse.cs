using PharmacyCleanArchitecture.Contracts.Brands.Common;

namespace PharmacyCleanArchitecture.Contracts.Brands.Get;

public record GetBrandListResponse(List<BrandResponse> Brands, int PageSize, int PageNumber, int MaxPages);