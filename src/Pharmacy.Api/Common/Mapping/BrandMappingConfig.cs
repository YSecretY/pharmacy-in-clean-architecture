using Mapster;
using Pharmacy.Application.Brands.Commands.Create;
using Pharmacy.Application.Brands.Commands.Remove;
using Pharmacy.Application.Brands.Commands.Update;
using Pharmacy.Application.Brands.Queries.GetBrandById;
using Pharmacy.Application.Brands.Queries.GetBrandList;
using Pharmacy.Contracts.Brands.Common;
using Pharmacy.Contracts.Brands.Create;
using Pharmacy.Contracts.Brands.Get;
using Pharmacy.Contracts.Brands.Remove;
using Pharmacy.Contracts.Brands.Update;
using Pharmacy.Domain.Brands;

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
            .Map(dest => dest.Name, src => src.Name.Value)
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

        config.NewConfig<UpdateBrandRequest, UpdateBrandCommand>()
            .Map(dest => dest.Guid, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.LogoImageUrl, src => src.ImageLogoUrl);

        config.NewConfig<RemoveBrandByIdRequest, RemoveBrandByIdCommand>()
            .Map(dest => dest.Guid, src => src.BrandId);
    }
}