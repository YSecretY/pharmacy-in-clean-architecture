using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;
using PharmacyCleanArchitecture.Domain.Brands;
using PharmacyCleanArchitecture.Domain.Categories;
using PharmacyCleanArchitecture.Domain.OrderAggregate;
using PharmacyCleanArchitecture.Domain.OrderAggregate.Entities;
using PharmacyCleanArchitecture.Domain.PharmacyAggregate.Entities;
using PharmacyCleanArchitecture.Domain.Products;
using PharmacyCleanArchitecture.Domain.Users;

namespace PharmacyCleanArchitecture.Infrastructure.Common.Persistence;

public class PharmacyDbContext : DbContext, IPharmacyDbContext
{
    public PharmacyDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Brand> Brands { get; set; } = null!;

    public DbSet<Category> Categories { get; set; } = null!;

    public DbSet<Order> Orders { get; set; } = null!;

    public DbSet<ProductInfo> ProductInfos { get; set; } = null!;

    public DbSet<OrderItem> OrderItems { get; set; } = null!;

    public DbSet<Domain.PharmacyAggregate.Pharmacy> Pharmacies { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;
}