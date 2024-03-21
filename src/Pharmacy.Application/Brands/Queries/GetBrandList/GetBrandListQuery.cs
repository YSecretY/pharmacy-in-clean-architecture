using MediatR;
using ErrorOr;

namespace Pharmacy.Application.Brands.Queries.GetBrandList;

public record GetBrandListQuery(int PageSize, int PageNumber) : IRequest<ErrorOr<GetBrandListQueryResponse>>;