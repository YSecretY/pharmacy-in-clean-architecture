using Mapster;
using PharmacyCleanArchitecture.Application.Orders.Commands;
using PharmacyCleanArchitecture.Contracts.Orders.Create;

namespace PharmacyCleanArchitecture.Api.Common.Mapping;

public class OrderMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateOrderRequest, CreateOrderCommand>()
            .Map(dest => dest.PharmacyId, src => src.PharmacyId)
            .Map(dest => dest.CountryCode, src => src.CountryCode)
            .Map(dest => dest.City, src => src.City)
            .Map(dest => dest.PostalCode, src => src.PostalCode)
            .Map(dest => dest.Street, src => src.Street)
            .Map(dest => dest.OrderItems, src => src.OrderItems);
    }
}