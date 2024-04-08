namespace PharmacyCleanArchitecture.Contracts.Pharmacies.RemoveProducts;

public record RemovePharmacyProductByIdRequest(Guid PharmacyId, Guid ProductId);