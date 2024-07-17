using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Warehouse.Application.Common;
using Warehouse.Domain.Products;
using Warehouse.Domain.Transactions;
using Warehouse.Domain.Warehouses;
using Warehouse.Domain.WarehousesSize;
using Warehouse.Domain.Workers;

namespace Warehouse.Infrastructure.Common;
public class WarehouseDbContext : DbContext, IUnitOfWork
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Transaction> Transactions { get; set; } = null!;
    public DbSet<WarehouseRack> WarehouseRacks { get; set; } = null!;
    public DbSet<WarehouseSize> WarehousesSize { get; set; } = null!;
    public DbSet<Worker> Workers { get; set; } = null!;

    public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options)
    {
    }

    public async Task CommitChangesAsync()
    {
        await SaveChangesAsync();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
