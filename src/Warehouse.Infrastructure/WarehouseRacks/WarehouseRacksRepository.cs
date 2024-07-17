using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Common;
using Warehouse.Domain.Warehouses;
using Warehouse.Infrastructure.Common;

namespace Warehouse.Infrastructure.Products;
public class WarehouseRacksRepository : IWarehouseRacksRepository
{
    private readonly WarehouseDbContext _dbContext;

    public WarehouseRacksRepository(WarehouseDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddWarehouseRackAsync(WarehouseRack WarehouseRack)
    {
        await _dbContext.WarehouseRacks.AddAsync(WarehouseRack);
    }

    public async Task<WarehouseRack?> GetByIdAsync(Guid id)
    {
        return await _dbContext.WarehouseRacks.FirstOrDefaultAsync(WarehouseRack => WarehouseRack.Id == id);
    }

    public async Task<List<WarehouseRack>> ListAsync()
    {
        return await _dbContext.WarehouseRacks.ToListAsync();
    }

    public Task RemoveWarehouseRackAsync(WarehouseRack WarehouseRack)
    {
        _dbContext.Remove(WarehouseRack);

        return Task.CompletedTask;
    }

    public Task UpdateWarehouseRackAsync(WarehouseRack WarehouseRack)
    {
        _dbContext.Update(WarehouseRack);

        return Task.CompletedTask;
    }
}
