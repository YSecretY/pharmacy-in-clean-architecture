namespace PharmacyCleanArchitecture.Contracts.Pharmacies.AddProducts;

public record AddExistingProductToPharmacyRequest(
    Guid PharmacyId,
    Guid ProductId,
    int Quantity,
    decimal? DiscountedPrice,
    bool IsInStock
);