using ErrorOr;
using MediatR;

namespace PharmacyCleanArchitecture.Application.Products.Queries.GetList;

public record GetProductsListQuery(int PageSize, int PageNumber) : IRequest<ErrorOr<GetProductsListQueryResponse>>;