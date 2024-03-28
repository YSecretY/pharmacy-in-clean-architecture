using System.Reflection;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PharmacyCleanArchitecture.Application.Brands.Commands.Create;
using PharmacyCleanArchitecture.Application.Brands.Commands.Remove;
using PharmacyCleanArchitecture.Application.Brands.Commands.Update;
using PharmacyCleanArchitecture.Application.Brands.Queries.GetBrandById;
using PharmacyCleanArchitecture.Application.Brands.Queries.GetBrandList;
using PharmacyCleanArchitecture.Application.Categories.Commands.Create;
using PharmacyCleanArchitecture.Application.Categories.Commands.Remove;
using PharmacyCleanArchitecture.Application.Categories.Commands.Update;
using PharmacyCleanArchitecture.Application.Categories.Queries.GetCategoryById;
using PharmacyCleanArchitecture.Application.Categories.Queries.GetCategoryList;
using PharmacyCleanArchitecture.Application.Pharmacies.Commands.AddProducts;
using PharmacyCleanArchitecture.Application.Pharmacies.Commands.AddProducts.Existing;
using PharmacyCleanArchitecture.Application.Pharmacies.Commands.AddProducts.New;
using PharmacyCleanArchitecture.Application.Pharmacies.Commands.Create;
using PharmacyCleanArchitecture.Application.Products.Commands.Create;
using PharmacyCleanArchitecture.Application.Products.Commands.Remove;
using PharmacyCleanArchitecture.Application.Products.Queries.GetById;
using PharmacyCleanArchitecture.Application.Products.Queries.GetList;
using PharmacyCleanArchitecture.Application.Users.Commands.ChangeEmail;
using PharmacyCleanArchitecture.Application.Users.Commands.ChangePassword;
using PharmacyCleanArchitecture.Application.Users.Commands.EmailConfirmation;
using PharmacyCleanArchitecture.Application.Users.Commands.Login;
using PharmacyCleanArchitecture.Application.Users.Commands.MakeAdmin;
using PharmacyCleanArchitecture.Application.Users.Commands.Register;
using PharmacyCleanArchitecture.Application.Users.Commands.UpdatePhoneNumber;
using PharmacyCleanArchitecture.Contracts.Pharmacies.AddProducts;
using PharmacyCleanArchitecture.Domain.Brands;
using PharmacyCleanArchitecture.Domain.Categories;
using PharmacyCleanArchitecture.Domain.PharmacyAggregate;
using PharmacyCleanArchitecture.Domain.Products;

namespace PharmacyCleanArchitecture.Application;

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
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }

    private static IServiceCollection AddDefaultServices(this IServiceCollection services)
    {
        services.AddScoped<IRequestHandler<CreateBrandCommand, ErrorOr<Brand>>, CreateBrandCommandHandler>();
        services.AddScoped<IRequestHandler<GetBrandByIdQuery, ErrorOr<Brand>>, GetBrandByIdQueryHandler>();
        services.AddScoped<IRequestHandler<GetBrandListQuery, ErrorOr<GetBrandListQueryResponse>>, GetBrandListQueryHandler>();
        services.AddScoped<IRequestHandler<UpdateBrandCommand, ErrorOr<Brand>>, UpdateBrandCommandHandler>();
        services.AddScoped<IRequestHandler<RemoveBrandByIdCommand, ErrorOr<Deleted>>, RemoveBrandByIdCommandHandler>();

        services.AddScoped<IRequestHandler<CreateCategoryCommand, ErrorOr<Category>>, CreateCategoryCommandHandler>();
        services.AddScoped<IRequestHandler<GetCategoryByIdQuery, ErrorOr<Category>>, GetCategoryByIdQueryHandler>();
        services.AddScoped<IRequestHandler<GetCategoryListQuery, ErrorOr<GetCategoryListQueryResponse>>, GetCategoryListQueryHandler>();
        services.AddScoped<IRequestHandler<UpdateCategoryCommand, ErrorOr<Category>>, UpdateCategoryCommandHandler>();
        services.AddScoped<IRequestHandler<RemoveCategoryByIdCommand, ErrorOr<Deleted>>, RemoveCategoryByIdCommandHandler>();

        services.AddScoped<IRequestHandler<RegisterUserCommand, ErrorOr<Created>>, RegisterUserCommandHandler>();
        services.AddScoped<IRequestHandler<LoginUserCommand, ErrorOr<string>>, LoginUserCommandHandler>();
        services.AddScoped<IRequestHandler<ConfirmEmailCommand, ErrorOr<Success>>, ConfirmEmailCommandHandler>();
        services.AddScoped<IRequestHandler<ChangePasswordCommand, ErrorOr<Updated>>, ChangePasswordCommandHandler>();
        services.AddScoped<IRequestHandler<SendEmailChangeConfirmationCommand, ErrorOr<Success>>, SendEmailChangeConfirmationCommandHandler>();
        services.AddScoped<IRequestHandler<ChangeEmailCommand, ErrorOr<Updated>>, ChangeEmailCommandHandler>();
        services.AddScoped<IRequestHandler<MakeAdminUserCommand, ErrorOr<Updated>>, MakeAdminUserCommandHandler>();
        services.AddScoped<IRequestHandler<UpdatePhoneNumberUserCommand, ErrorOr<Updated>>, UpdatePhoneNumberUserCommandHandler>();

        services.AddScoped<IRequestHandler<CreateProductCommand, ErrorOr<Created>>, CreateProductCommandHandler>();
        services.AddScoped<IRequestHandler<GetProductByIdQuery, ErrorOr<Product>>, GetProductByIdQueryHandler>();
        services.AddScoped<IRequestHandler<GetProductsListQuery, ErrorOr<GetProductsListQueryResponse>>, GetProductListQueryHandler>();
        services.AddScoped<IRequestHandler<RemoveProductByIdCommand, ErrorOr<Deleted>>, RemoveProductByIdCommandHandler>();

        services.AddScoped<IRequestHandler<CreatePharmacyCommand, ErrorOr<Pharmacy>>, CreatePharmacyCommandHandler>();
        services.AddScoped<IRequestHandler<AddNewProductToPharmacyCommand, ErrorOr<Success>>, AddNewProductToPharmacyCommandHandler>();
        services.AddScoped<IRequestHandler<AddExistingProductToPharmacyCommand, ErrorOr<Success>>, AddExistingProductToPharmacyCommandHandler>();

        return services;
    }
}