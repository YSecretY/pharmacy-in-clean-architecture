using PharmacyCleanArchitecture.Contracts.Categories.Common;

namespace PharmacyCleanArchitecture.Contracts.Categories.Get;

public record GetCategoryListResponse(List<CategoryResponse> Categories, int PageSize, int PageNumber, int MaxPages);