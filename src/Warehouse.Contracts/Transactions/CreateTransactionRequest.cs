namespace Warehouse.Contracts.Transactions;
public record CreateTransactionRequest(
    Guid ProductId,
    int TransactionQuantity,
    TransactionType TransactionType,
    DateTime Date,
    Guid WarehouseSizeId,
    int Sector,
    int Rack,
    Guid WorkerId);