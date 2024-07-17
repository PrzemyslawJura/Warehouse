using Warehouse.Domain.Products;
using Warehouse.Domain.Warehouses;
using Warehouse.Domain.Workers;

namespace Warehouse.Domain.Transactions;
public class Transaction
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public TransactionType Type { get; set; }
    public DateTime Date { get; set; }

    public Product Products { get; set; }
    public WarehouseRack WarehousesRack { get; set; }
    public Worker Workers { get; set; }

    public Guid ProductId { get; set; }
    public Guid WarehouseRackId { get; set; }
    public Guid WorkerId { get; set; }


    public Transaction(
        int quantity,
        TransactionType type,
        DateTime date,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Quantity = quantity;
        Type = type;
        Date = date;
    }

    public Transaction() { }
}