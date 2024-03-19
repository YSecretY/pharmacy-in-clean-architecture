using Mapster;
using Pharmacy.Application.Brands;
using Pharmacy.Contracts.Brands;
using Pharmacy.Domain.Brand;

namespace Pharmacy.Api.Common.Mapping;

public class BrandMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateBrandRequest, CreateBrandCommand>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.ImageLogoUrl, src => src.ImageLogoUrl);

        config.NewConfig<Brand, BrandResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.LogoImageUrl, src => src.LogoImageUrl);
    }
}