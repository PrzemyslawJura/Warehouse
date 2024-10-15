namespace Warehouse.Contracts.WarehousesRacks;
public record CreateWarehouseRackRequest(int Sector, int Rack, int Quantity, Guid WarehouseSizeId);