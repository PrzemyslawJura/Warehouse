using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Common;
using Warehouse.Domain.Products;
using Warehouse.Infrastructure.Common;

namespace Warehouse.Infrastructure.Products;
public class ProductsRepository : IProductsRepository
{
    private readonly WarehouseDbContext _dbContext;

    public ProductsRepository(WarehouseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddProductAsync(Product product)
    {
        await _dbContext.Products.AddAsync(product);
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(product => product.Id == id);
    }

    public async Task<List<Product>> ListAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public Task RemoveProductAsync(Product product)
    {
        _dbContext.Remove(product);

        return Task.CompletedTask;
    }

    public Task UpdateProductAsync(Product product)
    {
        _dbContext.Update(product);

        return Task.CompletedTask;
    }
}
