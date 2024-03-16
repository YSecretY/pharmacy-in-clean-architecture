using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Entities.Brand.Entities;
using Pharmacy.Domain.Entities.Category.Entities;
using Pharmacy.Domain.Entities.City.Entities;
using Pharmacy.Domain.Entities.Country.Entities;
using Pharmacy.Domain.Entities.Order.Entities;
using Pharmacy.Domain.Entities.Product.Entities;
using Pharmacy.Domain.Entities.User.Entities;

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

    public DbSet<City> Cities { get; set; } = null!;

    public DbSet<Country> Countries { get; set; } = null!;

    public DbSet<Order> Orders { get; set; } = null!;

    public DbSet<Domain.Entities.Pharmacy.Entities.Pharmacy> Pharmacies { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;
}