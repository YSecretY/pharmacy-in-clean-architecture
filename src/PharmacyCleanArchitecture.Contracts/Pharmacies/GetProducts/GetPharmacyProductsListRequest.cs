namespace PharmacyCleanArchitecture.Contracts.Pharmacies.GetProducts;

public record GetPharmacyProductsListRequest(Guid PharmacyId, int PageNumber, int PageSize);