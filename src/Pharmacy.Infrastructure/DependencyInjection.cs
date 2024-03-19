using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Application.Interfaces.Persistence;
using Pharmacy.Infrastructure.Common.Persistence;
using Pharmacy.Infrastructure.Persistence;

namespace Pharmacy.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PharmacyDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PharmacyDbConnection")));
        services.AddScoped<IBrandRepository, BrandRepository>();

        return services;
    }
}