using MediatR;
using ErrorOr;

namespace Pharmacy.Application.Products.Queries.GetList;

public record GetProductsListQuery(int PageSize, int PageNumber) : IRequest<ErrorOr<GetProductsListQueryResponse>>;