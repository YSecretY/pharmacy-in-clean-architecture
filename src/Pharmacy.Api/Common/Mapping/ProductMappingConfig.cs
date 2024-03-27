using Mapster;
using Pharmacy.Application.Products.Commands.Create;
using Pharmacy.Application.Products.Commands.Remove;
using Pharmacy.Application.Products.Queries.GetById;
using Pharmacy.Contracts.Products.Common;
using Pharmacy.Contracts.Products.Create;
using Pharmacy.Contracts.Products.Get;
using Pharmacy.Contracts.Products.Remove;
using Pharmacy.Domain.Product;

namespace Pharmacy.Api.Common.Mapping;

public class ProductMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateProductRequest, CreateProductCommand>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Sku, src => src.Sku)
            .Map(dest => dest.ImageUrl, src => src.ImageUrl)
            .Map(dest => dest.BrandId, src => src.BrandId)
            .Map(dest => dest.CategoryId, src => src.CategoryId)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Description, src => src.Description);

        config.NewConfig<Product, ProductResponse>()
            .Map(dest => dest.ProductId, src => src.Id)
            .Map(dest => dest.Sku, src => src.Sku)
            .Map(dest => dest.ImageUrl, src => src.ImageUrl)
            .Map(dest => dest.Brand, src => src.Brand)
            .Map(dest => dest.Category, src => src.Category)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Description, src => src.Description);

        config.NewConfig<GetProductRequest, GetProductByIdCommand>()
            .Map(dest => dest.Id, src => src.ProductId);

        config.NewConfig<RemoveProductByIdRequest, RemoveProductByIdCommand>()
            .Map(dest => dest.Id, src => src.ProductId);
    }
}