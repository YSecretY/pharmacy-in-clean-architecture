using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Application.Brands.Commands.CreateBrand;
using Pharmacy.Application.Brands.Commands.RemoveBrand;
using Pharmacy.Application.Brands.Commands.UpdateBrand;
using Pharmacy.Application.Brands.Queries.GetBrandById;
using Pharmacy.Application.Brands.Queries.GetBrandList;
using Pharmacy.Domain.Brand;

namespace Pharmacy.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddDefaultServices();
        services.AddValidators();

        return services;
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateBrandCommand>, CreateBrandCommandValidator>();
        services.AddScoped<IValidator<GetBrandListQuery>, GetBrandListQueryValidator>();
        services.AddScoped<IValidator<UpdateBrandCommand>, UpdateBrandCommandValidator>();

        return services;
    }

    private static IServiceCollection AddDefaultServices(this IServiceCollection services)
    {
        services.AddScoped<IRequestHandler<CreateBrandCommand, ErrorOr<Brand>>, CreateBrandCommandHandler>();
        services.AddScoped<IRequestHandler<GetBrandByIdQuery, ErrorOr<Brand>>, GetBrandByIdQueryHandler>();
        services.AddScoped<IRequestHandler<GetBrandListQuery, ErrorOr<GetBrandListQueryResponse>>, GetBrandListQueryHandler>();
        services.AddScoped<IRequestHandler<UpdateBrandCommand, ErrorOr<Brand>>, UpdateBrandCommandHandler>();
        services.AddScoped<IRequestHandler<RemoveBrandByIdCommand, ErrorOr<Success>>, RemoveBrandByIdCommandHandler>();

        return services;
    }
}