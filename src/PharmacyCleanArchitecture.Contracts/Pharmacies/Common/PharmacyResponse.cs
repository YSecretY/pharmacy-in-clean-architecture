namespace PharmacyCleanArchitecture.Contracts.Pharmacies.Common;

public record PharmacyResponse(Guid PharmacyId, string Name, string CountryIsoCode, string City, string PostalCode, string Street);