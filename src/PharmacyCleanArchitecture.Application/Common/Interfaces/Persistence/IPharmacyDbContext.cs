using Microsoft.EntityFrameworkCore;
using PharmacyCleanArchitecture.Domain.Brands;
using PharmacyCleanArchitecture.Domain.Categories;
using PharmacyCleanArchitecture.Domain.OrderAggregate;
using PharmacyCleanArchitecture.Domain.PharmacyAggregate.Entities;
using PharmacyCleanArchitecture.Domain.Products;
using PharmacyCleanArchitecture.Domain.Users;

namespace PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;

public interface IPharmacyDbContext
{
    public DbSet<Brand> Brands { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<ProductInfo> ProductInfos { get; set; }

    public DbSet<Domain.PharmacyAggregate.Pharmacy> Pharmacies { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Product> Products { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}