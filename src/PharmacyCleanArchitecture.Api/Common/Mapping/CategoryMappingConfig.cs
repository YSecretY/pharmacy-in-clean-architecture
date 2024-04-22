using Mapster;
using PharmacyCleanArchitecture.Application.Categories.Commands.Create;
using PharmacyCleanArchitecture.Application.Categories.Commands.Remove;
using PharmacyCleanArchitecture.Application.Categories.Commands.Update;
using PharmacyCleanArchitecture.Application.Categories.Queries.GetCategoryById;
using PharmacyCleanArchitecture.Application.Categories.Queries.GetCategoryList;
using PharmacyCleanArchitecture.Contracts.Categories.Common;
using PharmacyCleanArchitecture.Contracts.Categories.Create;
using PharmacyCleanArchitecture.Contracts.Categories.Get;
using PharmacyCleanArchitecture.Contracts.Categories.Remove;
using PharmacyCleanArchitecture.Contracts.Categories.Update;
using PharmacyCleanArchitecture.Domain.Categories;

namespace PharmacyCleanArchitecture.Api.Common.Mapping;

public class CategoryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCategoryRequest, CreateCategoryCommand>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.ImageUrl, src => src.ImageUrl);

        config.NewConfig<Category, CategoryResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name.Value)
            .Map(dest => dest.ImageUrl, src => src.ImageUrl);

        config.NewConfig<GetCategoryByIdRequest, GetCategoryByIdQuery>()
            .Map(dest => dest.Guid, src => src.CategoryId);

        config.NewConfig<GetCategoryListRequest, GetCategoryListQuery>()
            .Map(dest => dest.PageSize, src => src.PageSize)
            .Map(dest => dest.PageNumber, src => src.PageNumber);

        config.NewConfig<GetCategoryListQueryResponse, GetCategoryListResponse>()
            .Map(dest => dest.Categories, src => src.Categories)
            .Map(dest => dest.PageNumber, src => src.PageNumber)
            .Map(dest => dest.PageSize, src => src.PageSize)
            .Map(dest => dest.MaxPages, src => src.MaxPages);

        config.NewConfig<UpdateCategoryRequest, UpdateCategoryCommand>()
            .Map(dest => dest.Guid, src => src.CategoryId)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.ImageUrl, src => src.ImageUrl);

        config.NewConfig<RemoveCategoryByIdRequest, RemoveCategoryByIdCommand>()
            .Map(dest => dest.Guid, src => src.CategoryId);
    }
}