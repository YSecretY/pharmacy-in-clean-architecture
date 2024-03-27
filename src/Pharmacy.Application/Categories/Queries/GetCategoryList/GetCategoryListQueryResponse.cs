using Pharmacy.Domain.Categories;

namespace Pharmacy.Application.Categories.Queries.GetCategoryList;

public record GetCategoryListQueryResponse(List<Category> Categories, int PageSize, int PageNumber, int MaxPages);