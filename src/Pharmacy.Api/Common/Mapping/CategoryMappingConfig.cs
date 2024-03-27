using Mapster;
using Pharmacy.Application.Categories.Commands.Create;
using Pharmacy.Application.Categories.Commands.Remove;
using Pharmacy.Application.Categories.Commands.Update;
using Pharmacy.Application.Categories.Queries.GetCategoryById;
using Pharmacy.Application.Categories.Queries.GetCategoryList;
using Pharmacy.Contracts.Categories.Common;
using Pharmacy.Contracts.Categories.Create;
using Pharmacy.Contracts.Categories.Get;
using Pharmacy.Contracts.Categories.Remove;
using Pharmacy.Contracts.Categories.Update;
using Pharmacy.Domain.Category;

namespace Pharmacy.Api.Common.Mapping;

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