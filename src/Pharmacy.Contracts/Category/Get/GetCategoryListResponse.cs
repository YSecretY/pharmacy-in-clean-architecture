using Pharmacy.Contracts.Category.Common;

namespace Pharmacy.Contracts.Category.Get;

public record GetCategoryListResponse(List<CategoryResponse> Categories, int PageSize, int PageNumber, int MaxPages);