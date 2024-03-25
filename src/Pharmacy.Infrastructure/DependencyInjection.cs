using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Application.Common.Interfaces.Auth;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Application.Common.Services;
using Pharmacy.Infrastructure.Auth;
using Pharmacy.Infrastructure.Common.Persistence;
using Pharmacy.Infrastructure.Services;

namespace Pharmacy.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        services.AddAuth(configuration);
        services.AddServices();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IPharmacyDbContext, PharmacyDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PharmacyDbConnection")));

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}