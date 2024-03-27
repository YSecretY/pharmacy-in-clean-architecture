namespace Pharmacy.Contracts.Products;

public record CreateProductRequest(
    string Name,
    string? Sku,
    string ImageUrl,
    Guid BrandId,
    Guid CategoryId,
    decimal Price,
    string? Description
);