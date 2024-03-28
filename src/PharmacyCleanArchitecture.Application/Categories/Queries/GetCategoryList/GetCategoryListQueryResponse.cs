using PharmacyCleanArchitecture.Domain.Categories;

namespace PharmacyCleanArchitecture.Application.Categories.Queries.GetCategoryList;

public record GetCategoryListQueryResponse(List<Category> Categories, int PageSize, int PageNumber, int MaxPages);