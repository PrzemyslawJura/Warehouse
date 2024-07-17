using Warehouse.Domain.Warehouses;

namespace Warehouse.Application.Common;
public interface IWarehouseRacksRepository
{
    Task AddWarehouseRackAsync(WarehouseRack warehouseRack);
    Task<WarehouseRack?> GetByIdAsync(Guid id);
    Task<List<WarehouseRack>> ListAsync();
    Task UpdateWarehouseRackAsync(WarehouseRack warehouseRack);
    Task RemoveWarehouseRackAsync(WarehouseRack warehouseRack);
}
