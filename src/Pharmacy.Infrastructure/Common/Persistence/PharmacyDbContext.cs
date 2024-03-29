using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Domain.Brand;
using Pharmacy.Domain.Category;
using Pharmacy.Domain.PharmacyAggregate.Entities;
using Pharmacy.Domain.User;

namespace Pharmacy.Infrastructure.Common.Persistence;

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

    public DbSet<Domain.PharmacyAggregate.Pharmacy> Pharmacies { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;
}