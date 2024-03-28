using MediatR;
using ErrorOr;

namespace PharmacyCleanArchitecture.Application.Pharmacies.Queries.GetProductById;

public record GetPharmacyProductByIdQuery(Guid PharmacyId, Guid ProductId) : IRequest<ErrorOr<GetPharmacyProductByIdQueryResponse>>;