namespace Warehouse.Contracts.WarehousesRacks;
public record UpdateWarehouseRackRequest(Guid Id, int Sector, int Rack, int Quantity, Guid WarehouseSizeId);