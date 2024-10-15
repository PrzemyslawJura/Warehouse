namespace Warehouse.Contracts.WarehousesRacks;
public record WarehouseRackResponse(Guid Id, int Sector, int Rack, int Quantity, Guid WarehouseSizeId);