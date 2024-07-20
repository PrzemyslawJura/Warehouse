namespace Warehouse.Contracts.Transactions;
public record CommandTransactionResponse(
    Guid TransactionId,
    Guid ProductId,
    int TransactionQuantity,
    string TransactionType,
    DateTime Date,
    Guid WarehouseSizeId,
    Guid WorkerId);