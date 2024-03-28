using Mapster;
using PharmacyCleanArchitecture.Application.Pharmacies.Commands.AddProducts;
using PharmacyCleanArchitecture.Application.Pharmacies.Commands.Create;
using PharmacyCleanArchitecture.Contracts.Pharmacies.AddProducts;
using PharmacyCleanArchitecture.Contracts.Pharmacies.Common;
using PharmacyCleanArchitecture.Contracts.Pharmacies.Create;
using PharmacyCleanArchitecture.Domain.PharmacyAggregate;

namespace PharmacyCleanArchitecture.Api.Common.Mapping;

public class PharmacyMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreatePharmacyRequest, CreatePharmacyCommand>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.CountryIsoCode, src => src.CountryIsoCode)
            .Map(dest => dest.City, src => src.City)
            .Map(dest => dest.PostalCode, src => src.PostalCode)
            .Map(dest => dest.Street, src => src.Street);

        config.NewConfig<Pharmacy, PharmacyResponse>()
            .Map(dest => dest.Name, src => src.Name.Value)
            .Map(dest => dest.CountryIsoCode, src => src.Address.Country)
            .Map(dest => dest.City, src => src.Address.City)
            .Map(dest => dest.PostalCode, src => src.Address.PostalCode)
            .Map(dest => dest.Street, src => src.Address.Street);

        config.NewConfig<AddNewProductToPharmacyRequest, AddNewProductToPharmacyCommand>()
            .Map(dest => dest.PharmacyId, src => src.PharmacyId)
            .Map(dest => dest.CreateProductCommand, src => src.CreateProductRequest)
            .Map(dest => dest.Quantity, src => src.Quantity)
            .Map(dest => dest.DiscountedPrice, src => src.DiscountedPrice)
            .Map(dest => dest.IsInStock, src => src.IsInStock);
    }
}