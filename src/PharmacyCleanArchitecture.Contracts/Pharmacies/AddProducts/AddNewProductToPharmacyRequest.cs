using PharmacyCleanArchitecture.Contracts.Products.Create;

namespace PharmacyCleanArchitecture.Contracts.Pharmacies.AddProducts;

public record AddNewProductToPharmacyRequest(
    Guid PharmacyId,
    CreateProductRequest CreateProductRequest,
    int Quantity,
    decimal? DiscountedPrice,
    bool IsInStock
);