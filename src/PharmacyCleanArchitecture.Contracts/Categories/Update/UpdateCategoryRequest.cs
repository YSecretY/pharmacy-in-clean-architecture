namespace PharmacyCleanArchitecture.Contracts.Categories.Update;

public record UpdateCategoryRequest(Guid CategoryId, string Name, string? ImageUrl);