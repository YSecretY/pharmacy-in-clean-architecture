using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.Brands;
using Pharmacy.Domain.Categories;
using Pharmacy.Domain.PharmacyAggregate.Entities;
using Pharmacy.Domain.Products;
using Pharmacy.Domain.Users;

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