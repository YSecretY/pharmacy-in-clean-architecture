using PharmacyCleanArchitecture.Domain.Brands;
using PharmacyCleanArchitecture.Domain.Categories;

namespace PharmacyCleanArchitecture.Application.Pharmacies.Queries.GetProductById;

public record GetPharmacyProductByIdQueryResponse(
    Guid ProductId,
    string Name,
    string? Sku,
    string ImageUrl,
    Brand Brand,
    Category Category,
    decimal Price,
    string? Description,
    int Quantity,
    bool IsInStock,
    decimal? DiscountedPrice
);