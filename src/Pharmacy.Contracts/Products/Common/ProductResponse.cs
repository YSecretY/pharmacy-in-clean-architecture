using Pharmacy.Contracts.Brands.Common;
using Pharmacy.Contracts.Categories.Common;

namespace Pharmacy.Contracts.Products.Common;

public record ProductResponse(
    Guid ProductId,
    string Name,
    string Sku,
    string ImageUrl,
    BrandResponse Brand,
    CategoryResponse Category,
    decimal Price, string Description
);