using PharmacyCleanArchitecture.Domain.Products;

namespace PharmacyCleanArchitecture.Application.Pharmacies.Queries.GetProductsList;

public record GetPharmacyProductsListQueryResponse(Guid PharmacyId, List<Product> Products, int PageSize, int PageNumber, int MaxPages);