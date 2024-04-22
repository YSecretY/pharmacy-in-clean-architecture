using ErrorOr;
using MediatR;

namespace PharmacyCleanArchitecture.Application.Brands.Queries.GetBrandList;

public record GetBrandListQuery(int PageSize, int PageNumber) : IRequest<ErrorOr<GetBrandListQueryResponse>>;