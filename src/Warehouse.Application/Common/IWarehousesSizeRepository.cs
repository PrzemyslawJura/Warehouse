using Warehouse.Domain.WarehousesSize;

namespace Warehouse.Application.Common;
public interface IWarehousesSizeRepository
{
    Task AddWarehouseSizeAsync(WarehouseSize warehouseSize);
    Task<WarehouseSize?> GetByIdAsync(Guid id);
    Task<List<WarehouseSize>> ListAsync();
    Task UpdateWarehouseSizeAsync(WarehouseSize warehouseSize);
    Task RemoveWarehouseSizeAsync(WarehouseSize warehouseSize);
}