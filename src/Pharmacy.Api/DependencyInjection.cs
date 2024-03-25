using System.Reflection;
using Mapster;
using MapsterMapper;
using Microsoft.OpenApi.Models;

namespace Pharmacy.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMappings();
        services.AddMediatR();
        services.AddSwagger();

        return services;
    }

    private static IServiceCollection AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }

    private static IServiceCollection AddMappings(this IServiceCollection services)
    {
        services.AddMapster();

        TypeAdapterConfig config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }

    private static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "PharmacyApi", Version = "v1" });
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter the token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
        return services;
    }
}