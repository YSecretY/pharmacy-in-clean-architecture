namespace Pharmacy.Contracts.Category.Update;

public record UpdateCategoryRequest(Guid CategoryId, string Name, string? ImageUrl);