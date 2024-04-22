using PharmacyCleanArchitecture.Contracts.Brands.Common;
using PharmacyCleanArchitecture.Contracts.Categories.Common;

namespace PharmacyCleanArchitecture.Contracts.Pharmacies.GetProducts;

public record GetPharmacyProductByIdResponse(
    Guid ProductId,
    string Name,
    string? Sku,
    string ImageUrl,
    BrandResponse Brand,
    CategoryResponse Category,
    decimal Price,
    string? Description,
    int Quantity,
    bool IsInStock,
    decimal? DiscountedPrice
);