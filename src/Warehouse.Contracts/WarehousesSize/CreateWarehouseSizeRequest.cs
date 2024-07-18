namespace Warehouse.Contracts.WarehousesSize;
public record CreateWarehouseSizeRequest(string Name, int SectorNumber, int RackQuantity);