namespace Warehouse.Contracts.WarehousesSize;
public record UpdateWarehouseSizeRequest(Guid Id, int SectorNumber, int RackQuantity);
