using MediatR;
using ErrorOr;

namespace Pharmacy.Application.Products.Create;

public record CreateProductCommand(
    string Name,
    string? Sku,
    string ImageUrl,
    Guid BrandId,
    Guid CategoryId,
    decimal Price,
    string? Description
) : IRequest<ErrorOr<Created>>;