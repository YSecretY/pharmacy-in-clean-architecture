using PharmacyCleanArchitecture.Contracts.Products.Common;

namespace PharmacyCleanArchitecture.Contracts.Pharmacies.GetProducts;

public record GetPharmacyProductsListResponse(Guid PharmacyId, List<ProductResponse> Products, int PageSize, int PageNumber, int MaxPages);