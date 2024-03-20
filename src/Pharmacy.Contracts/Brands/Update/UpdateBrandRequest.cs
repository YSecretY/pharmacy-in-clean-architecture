namespace Pharmacy.Contracts.Brands.Update;

public record UpdateBrandRequest(Guid Id, string Name, string? ImageLogoUrl);