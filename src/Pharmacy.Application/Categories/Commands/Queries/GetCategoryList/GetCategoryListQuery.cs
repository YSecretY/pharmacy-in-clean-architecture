using MediatR;
using ErrorOr;

namespace Pharmacy.Application.Categories.Commands.Queries.GetCategoryList;

public record GetCategoryListQuery(int PageSize, int PageNumber) : IRequest<ErrorOr<GetCategoryListQueryResponse>>;