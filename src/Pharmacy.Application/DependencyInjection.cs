using System.Reflection;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Application.Brands.Commands.Create;
using Pharmacy.Application.Brands.Commands.Remove;
using Pharmacy.Application.Brands.Commands.Update;
using Pharmacy.Application.Brands.Queries.GetBrandById;
using Pharmacy.Application.Brands.Queries.GetBrandList;
using Pharmacy.Application.Categories.Commands.Create;
using Pharmacy.Application.Categories.Commands.Remove;
using Pharmacy.Application.Categories.Commands.Update;
using Pharmacy.Application.Categories.Queries.GetCategoryById;
using Pharmacy.Application.Categories.Queries.GetCategoryList;
using Pharmacy.Application.Products.Create;
using Pharmacy.Application.Users.ChangeEmail;
using Pharmacy.Application.Users.ChangePassword;
using Pharmacy.Application.Users.EmailConfirmation;
using Pharmacy.Application.Users.Login;
using Pharmacy.Application.Users.MakeAdmin;
using Pharmacy.Application.Users.Register;
using Pharmacy.Application.Users.UpdatePhoneNumber;
using Pharmacy.Domain.Brand;
using Pharmacy.Domain.Category;
using Pharmacy.Domain.Product;

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

        services.AddScoped<IRequestHandler<CreateProductCommand, ErrorOr<Product>>, CreateProductCommandHandler>();

        return services;
    }
}