using Warehouse.Domain.Warehouses;

namespace Warehouse.Domain.WarehousesSize;
public class WarehouseSize
{
    public Guid Id { get; set; }
    public int SectorNumber { get; set; }
    public int RackQuantity { get; set; }

    public ICollection<WarehouseRack>? WarehousesRack { get; private set; }

    public WarehouseSize(
        int sectorNumber,
        int rackQuantity,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        SectorNumber = sectorNumber;
        RackQuantity = rackQuantity;
    }

    public WarehouseSize() { }
}
