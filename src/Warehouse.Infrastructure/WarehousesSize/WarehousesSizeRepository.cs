using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Common;
using Warehouse.Domain.WarehousesSize;
using Warehouse.Infrastructure.Common;

namespace Warehouse.Infrastructure.Products;
public class WarehousesSizeRepository : IWarehousesSizeRepository
{
    private readonly WarehouseDbContext _dbContext;

    public WarehousesSizeRepository(WarehouseDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddWarehouseSizeAsync(WarehouseSize WarehouseSize)
    {
        await _dbContext.WarehousesSize.AddAsync(WarehouseSize);
    }

    public async Task<WarehouseSize?> GetByIdAsync(Guid id)
    {
        return await _dbContext.WarehousesSize.FirstOrDefaultAsync(WarehouseSize => WarehouseSize.Id == id);
    }

    public async Task<List<WarehouseSize>> ListAsync()
    {
        return await _dbContext.WarehousesSize.ToListAsync();
    }

    public Task RemoveWarehouseSizeAsync(WarehouseSize WarehouseSize)
    {
        _dbContext.Remove(WarehouseSize);

        return Task.CompletedTask;
    }

    public Task UpdateWarehouseSizeAsync(WarehouseSize WarehouseSize)
    {
        _dbContext.Update(WarehouseSize);

        return Task.CompletedTask;
    }
}
