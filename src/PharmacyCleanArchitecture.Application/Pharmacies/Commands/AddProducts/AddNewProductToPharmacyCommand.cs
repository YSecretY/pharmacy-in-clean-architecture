using MediatR;
using ErrorOr;
using PharmacyCleanArchitecture.Application.Products.Commands.Create;

namespace PharmacyCleanArchitecture.Application.Pharmacies.Commands.AddProducts;

public record AddNewProductToPharmacyCommand(
    Guid PharmacyId,
    CreateProductCommand CreateProductCommand,
    int Quantity,
    decimal? DiscountedPrice,
    bool IsInStock
) : IRequest<ErrorOr<Success>>;