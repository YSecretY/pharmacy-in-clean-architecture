using ErrorOr;
using MediatR;

namespace PharmacyCleanArchitecture.Application.Categories.Queries.GetCategoryList;

public record GetCategoryListQuery(int PageSize, int PageNumber) : IRequest<ErrorOr<GetCategoryListQueryResponse>>;