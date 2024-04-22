namespace PharmacyCleanArchitecture.Contracts.Pharmacies.Create;

public record CreatePharmacyRequest(string Name, string CountryIsoCode, string City, string PostalCode, string Street);