using Mapster;
using PharmacyCleanArchitecture.Application.Pharmacies.Commands.AddProducts.Existing;
using PharmacyCleanArchitecture.Application.Pharmacies.Commands.AddProducts.New;
using PharmacyCleanArchitecture.Application.Pharmacies.Commands.Create;
using PharmacyCleanArchitecture.Application.Pharmacies.Queries.GetProductById;
using PharmacyCleanArchitecture.Application.Pharmacies.Queries.GetProductsList;
using PharmacyCleanArchitecture.Contracts.Pharmacies.AddProducts;
using PharmacyCleanArchitecture.Contracts.Pharmacies.Common;
using PharmacyCleanArchitecture.Contracts.Pharmacies.Create;
using PharmacyCleanArchitecture.Contracts.Pharmacies.GetProducts;
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

        config.NewConfig<AddExistingProductToPharmacyRequest, AddExistingProductToPharmacyCommand>()
            .Map(dest => dest.PharmacyId, src => src.PharmacyId)
            .Map(dest => dest.ProductId, src => src.ProductId)
            .Map(dest => dest.Quantity, src => src.Quantity)
            .Map(dest => dest.DiscountedPrice, src => src.DiscountedPrice)
            .Map(dest => dest.IsInStock, src => src.IsInStock);

        config.NewConfig<GetPharmacyProductByIdRequest, GetPharmacyProductByIdQuery>()
            .Map(dest => dest.PharmacyId, src => src.PharmacyId)
            .Map(dest => dest.PharmacyId, src => src.ProductId);

        config.NewConfig<GetPharmacyProductByIdQueryResponse, GetPharmacyProductByIdResponse>()
            .Map(dest => dest.ProductId, src => src.ProductId)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Sku, src => src.Sku)
            .Map(dest => dest.ImageUrl, src => src.ImageUrl)
            .Map(dest => dest.Brand, src => src.Brand)
            .Map(dest => dest.Category, src => src.Category)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Quantity, src => src.Quantity)
            .Map(dest => dest.IsInStock, src => src.IsInStock)
            .Map(dest => dest.DiscountedPrice, src => src.DiscountedPrice);

        config.NewConfig<GetPharmacyProductsListRequest, GetPharmacyProductsListQuery>()
            .Map(dest => dest.PharmacyId, src => src.PharmacyId)
            .Map(dest => dest.PageSize, src => src.PageSize)
            .Map(dest => dest.PageNumber, src => src.PageNumber);

        config.NewConfig<GetPharmacyProductsListQueryResponse, GetPharmacyProductsListResponse>()
            .Map(dest => dest.PharmacyId, src => src.PharmacyId)
            .Map(dest => dest.Products, src => src.Products)
            .Map(dest => dest.PageSize, src => src.PageSize)
            .Map(dest => dest.PageNumber, src => src.PageNumber)
            .Map(dest => dest.MaxPages, src => src.MaxPages);
    }
}