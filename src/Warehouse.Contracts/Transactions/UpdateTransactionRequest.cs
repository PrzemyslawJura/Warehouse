namespace Warehouse.Contracts.Transactions;
public record UpdateTransactionRequest(
    Guid TransactionId,
    Guid ProductId,
    int TransactionQuantity,
    TransactionType TransactionType,
    DateTime Date,
    Guid WarehouseSizeId,
    Guid WarehouseRackId,
    int Sector,
    int Rack,
    Guid WorkerId);