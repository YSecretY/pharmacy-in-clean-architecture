using Pharmacy.Contracts.Categories.Common;

namespace Pharmacy.Contracts.Categories.Get;

public record GetCategoryListResponse(List<CategoryResponse> Categories, int PageSize, int PageNumber, int MaxPages);