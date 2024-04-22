using PharmacyCleanArchitecture.Contracts.Products.Common;

namespace PharmacyCleanArchitecture.Contracts.Products.Get;

public record GetProductListResponse(List<ProductResponse> Products, int PageSize, int PageNumber, int MaxPages);