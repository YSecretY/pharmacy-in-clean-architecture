using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.Entities.Brand;
using Pharmacy.Domain.Entities.Category;
using Pharmacy.Domain.Entities.Pharmacy.Entities;
using Pharmacy.Domain.Entities.User;

namespace Pharmacy.Infrastructure.Common.Persistence;

public class PharmacyDbContext : DbContext
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

    public DbSet<Domain.Entities.Pharmacy.Pharmacy> Pharmacies { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;
}