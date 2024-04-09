using Mapster;
using PharmacyCleanArchitecture.Application.Orders.Commands;
using PharmacyCleanArchitecture.Application.Orders.Queries;
using PharmacyCleanArchitecture.Contracts.Orders.Common;
using PharmacyCleanArchitecture.Contracts.Orders.Create;
using PharmacyCleanArchitecture.Contracts.Orders.Get;
using PharmacyCleanArchitecture.Domain.OrderAggregate;

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

        config.NewConfig<GetOrderByIdRequest, GetOrderByIdQuery>()
            .Map(dest => dest.OrderId, src => src.OrderId);

        config.NewConfig<Order, OrderResponse>()
            .Map(dest => dest.OrderId, src => src.Id)
            .Map(dest => dest.PharmacyId, src => src.PharmacyId)
            .Map(dest => dest.CountryCode, src => src.ReceiverAddress.Country)
            .Map(dest => dest.City, src => src.ReceiverAddress.City)
            .Map(dest => dest.PostalCode, src => src.ReceiverAddress.PostalCode)
            .Map(dest => dest.Street, src => src.ReceiverAddress.Street)
            .Map(dest => dest.OrderItems, src => src.OrderItems);
    }
}