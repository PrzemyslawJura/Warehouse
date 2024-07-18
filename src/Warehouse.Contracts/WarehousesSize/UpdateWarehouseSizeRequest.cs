namespace Warehouse.Contracts.WarehousesSize;
public record UpdateWarehouseSizeRequest(Guid Id, string Name, int SectorNumber, int RackQuantity);
