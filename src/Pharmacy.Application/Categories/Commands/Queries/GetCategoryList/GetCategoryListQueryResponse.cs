using Pharmacy.Contracts.Category.Common;
using Pharmacy.Domain.Category;

namespace Pharmacy.Application.Categories.Commands.Queries.GetCategoryList;

public record GetCategoryListQueryResponse(List<Category> Categories, int PageSize, int PageNumber, int MaxPages);