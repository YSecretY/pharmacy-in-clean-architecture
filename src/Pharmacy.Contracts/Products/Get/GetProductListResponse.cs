using Pharmacy.Contracts.Products.Common;

namespace Pharmacy.Contracts.Products.Get;

public record GetProductListResponse(List<ProductResponse> Products, int PageSize, int PageNumber, int MaxPages);