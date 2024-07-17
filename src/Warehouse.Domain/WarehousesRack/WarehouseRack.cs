using Warehouse.Domain.Transactions;
using Warehouse.Domain.WarehousesSize;

namespace Warehouse.Domain.Warehouses;
public class WarehouseRack
{
    Guid Id { get; set; }
    public string Sector { get; set; }
    public string Rack { get; set; }
    public int Quantity { get; set; }

    public ICollection<Transaction>? Transactions { get; private set; }
    public WarehouseSize WarehouseSize { get; set; }

    public WarehouseRack(
        string sector,
        string rack,
        int quantity,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Sector = sector;
        Rack = rack;
        Quantity = quantity;
    }

    public WarehouseRack() { }
}
