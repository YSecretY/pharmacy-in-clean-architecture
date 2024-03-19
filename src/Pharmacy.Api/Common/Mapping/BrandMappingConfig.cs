using Mapster;
using Pharmacy.Application.Brands;
using Pharmacy.Application.Brands.Commands.CreateBrand;
using Pharmacy.Application.Brands.Queries.GetBrandById;
using Pharmacy.Application.Brands.Queries.GetBrandList;
using Pharmacy.Contracts.Brands;
using Pharmacy.Contracts.Brands.Common;
using Pharmacy.Contracts.Brands.Create;
using Pharmacy.Contracts.Brands.Get;
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

        config.NewConfig<GetBrandRequest, GetBrandByIdQuery>()
            .Map(dest => dest.Guid, src => src.Id);

        config.NewConfig<GetBrandListRequest, GetBrandListQuery>()
            .Map(dest => dest.PageNumber, src => src.PageNumber)
            .Map(dest => dest.PageSize, src => src.PageSize);

        config.NewConfig<GetBrandListQueryResponse, GetBrandListResponse>()
            .Map(dest => dest.PageNumber, src => src.PageNumber)
            .Map(dest => dest.Brands, src => src.Brands)
            .Map(dest => dest.PageSize, src => src.PageSize)
            .Map(dest => dest.MaxPages, src => src.MaxPages);
    }
}