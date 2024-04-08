using ErrorOr;
using MediatR;

namespace PharmacyCleanArchitecture.Application.Pharmacies.Commands.RemoveProducts;

public record RemovePharmacyProductByIdCommand(Guid PharmacyId, Guid ProductId) : IRequest<ErrorOr<Deleted>>;