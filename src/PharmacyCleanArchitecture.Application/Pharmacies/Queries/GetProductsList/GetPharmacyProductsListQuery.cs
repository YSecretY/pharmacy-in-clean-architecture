using MediatR;
using ErrorOr;

namespace PharmacyCleanArchitecture.Application.Pharmacies.Queries.GetProductsList;

public record GetPharmacyProductsListQuery
    (Guid PharmacyId, int PageSize, int PageNumber) : IRequest<ErrorOr<GetPharmacyProductsListQueryResponse>>;