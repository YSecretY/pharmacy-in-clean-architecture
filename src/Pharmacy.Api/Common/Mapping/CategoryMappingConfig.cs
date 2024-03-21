using Mapster;
using Pharmacy.Application.Categories.Commands.Create;
using Pharmacy.Application.Categories.Commands.Queries;
using Pharmacy.Contracts.Category.Common;
using Pharmacy.Contracts.Category.Create;
using Pharmacy.Contracts.Category.Get;
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
    }
}