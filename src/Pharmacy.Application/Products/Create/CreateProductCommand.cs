using MediatR;
using ErrorOr;
using Pharmacy.Domain.Product;

namespace Pharmacy.Application.Products.Create;

public record CreateProductCommand(
    string Name,
    string? Sku,
    string ImageUrl,
    Guid BrandId,
    Guid CategoryId,
    decimal Price,
    string? Description
) : IRequest<ErrorOr<Product>>;