namespace PharmacyCleanArchitecture.Contracts.Pharmacies.GetProducts;

public record GetPharmacyProductByIdRequest(Guid PharmacyId, Guid ProductId);