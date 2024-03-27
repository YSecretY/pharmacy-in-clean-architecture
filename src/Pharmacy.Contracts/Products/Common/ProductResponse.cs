using Pharmacy.Contracts.Brands.Common;
using Pharmacy.Contracts.Categories.Common;

namespace Pharmacy.Contracts.Products.Common;

public record ProductResponse(
    Guid ProductId,
    string Name,
    string Sku,
    string ImageUrl,
    Guid BrandId,
    Guid CategoryId,
    decimal Price, string Description
);