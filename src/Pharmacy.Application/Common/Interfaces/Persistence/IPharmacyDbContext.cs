using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.Brand;
using Pharmacy.Domain.Category;
using Pharmacy.Domain.PharmacyAggregate.Entities;
using Pharmacy.Domain.Product;
using Pharmacy.Domain.User;

namespace Pharmacy.Application.Common.Interfaces.Persistence;

public interface IPharmacyDbContext
{
    public DbSet<Brand> Brands { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Domain.PharmacyAggregate.Pharmacy> Pharmacies { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Product> Products { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}