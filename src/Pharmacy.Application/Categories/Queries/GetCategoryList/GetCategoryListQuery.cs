using ErrorOr;
using MediatR;

namespace Pharmacy.Application.Categories.Queries.GetCategoryList;

public record GetCategoryListQuery(int PageSize, int PageNumber) : IRequest<ErrorOr<GetCategoryListQueryResponse>>;