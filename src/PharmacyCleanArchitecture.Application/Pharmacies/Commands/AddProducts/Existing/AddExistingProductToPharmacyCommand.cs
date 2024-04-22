using ErrorOr;
using MediatR;

namespace PharmacyCleanArchitecture.Application.Pharmacies.Commands.AddProducts.Existing;

public record AddExistingProductToPharmacyCommand(
    Guid PharmacyId,
    Guid ProductId,
    int Quantity,
    decimal? DiscountedPrice,
    bool IsInStock
) : IRequest<ErrorOr<Success>>;