using PharmacyCleanArchitecture.Contracts.Brands.Common;
using PharmacyCleanArchitecture.Contracts.Categories.Common;

namespace PharmacyCleanArchitecture.Contracts.Products.Common;

public record ProductResponse(
    Guid ProductId,
    string Name,
    string Sku,
    string ImageUrl,
    BrandResponse Brand,
    CategoryResponse Category,
    decimal Price,
    string Description
);