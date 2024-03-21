using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Application.Brands.Commands.CreateBrand;
using Pharmacy.Application.Brands.Commands.RemoveBrand;
using Pharmacy.Application.Brands.Commands.UpdateBrand;
using Pharmacy.Application.Brands.Queries.GetBrandById;
using Pharmacy.Application.Brands.Queries.GetBrandList;
using Pharmacy.Application.Categories.Commands.Create;
using Pharmacy.Application.Categories.Commands.Queries;
using Pharmacy.Application.Categories.Commands.Queries.GetCategoryById;
using Pharmacy.Application.Categories.Commands.Queries.GetCategoryList;
using Pharmacy.Domain.Brand;
using Pharmacy.Domain.Category;

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

        services.AddScoped<IValidator<CreateCategoryCommand>, CreateCategoryCommandValidator>();
        services.AddScoped<IValidator<GetCategoryListQuery>, GetCategoryListQueryValidator>();

        return services;
    }

    private static IServiceCollection AddDefaultServices(this IServiceCollection services)
    {
        services.AddScoped<IRequestHandler<CreateBrandCommand, ErrorOr<Brand>>, CreateBrandCommandHandler>();
        services.AddScoped<IRequestHandler<GetBrandByIdQuery, ErrorOr<Brand>>, GetBrandByIdQueryHandler>();
        services.AddScoped<IRequestHandler<GetBrandListQuery, ErrorOr<GetBrandListQueryResponse>>, GetBrandListQueryHandler>();
        services.AddScoped<IRequestHandler<UpdateBrandCommand, ErrorOr<Brand>>, UpdateBrandCommandHandler>();
        services.AddScoped<IRequestHandler<RemoveBrandByIdCommand, ErrorOr<Success>>, RemoveBrandByIdCommandHandler>();

        services.AddScoped<IRequestHandler<CreateCategoryCommand, ErrorOr<Category>>, CreateCategoryCommandHandler>();
        services.AddScoped<IRequestHandler<GetCategoryByIdQuery, ErrorOr<Category>>, GetCategoryByIdQueryHandler>();
        services.AddScoped<IRequestHandler<GetCategoryListQuery, ErrorOr<GetCategoryListQueryResponse>>, GetCategoryListQueryHandler>();

        return services;
    }
}