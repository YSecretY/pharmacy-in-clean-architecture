using Mapster;
using PharmacyCleanArchitecture.Application.Brands.Commands.Create;
using PharmacyCleanArchitecture.Application.Brands.Commands.Remove;
using PharmacyCleanArchitecture.Application.Brands.Commands.Update;
using PharmacyCleanArchitecture.Application.Brands.Queries.GetBrandById;
using PharmacyCleanArchitecture.Application.Brands.Queries.GetBrandList;
using PharmacyCleanArchitecture.Contracts.Brands.Common;
using PharmacyCleanArchitecture.Contracts.Brands.Create;
using PharmacyCleanArchitecture.Contracts.Brands.Get;
using PharmacyCleanArchitecture.Contracts.Brands.Remove;
using PharmacyCleanArchitecture.Contracts.Brands.Update;
using PharmacyCleanArchitecture.Domain.Brands;

namespace PharmacyCleanArchitecture.Api.Common.Mapping;

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