using ErrorOr;
using MediatR;

namespace PharmacyCleanArchitecture.Application.Products.Commands.Create;

public record CreateProductCommand(
    string Name,
    string? Sku,
    string ImageUrl,
    Guid BrandId,
    Guid CategoryId,
    decimal Price,
    string? Description
) : IRequest<ErrorOr<Created>>;