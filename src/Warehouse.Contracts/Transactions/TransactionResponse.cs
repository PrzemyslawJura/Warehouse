namespace Warehouse.Contracts.Transactions;
public record TransactionResponse(
    Guid TransactionId,
    string ProductName,
    string ProductType,
    Guid ProductId,
    int TransactionQuantity,
    string TransactionType,
    DateTime Date,
    string WarehouseName,
    int Sector,
    int Rack,
    string FirstName,
    string LastName,
    string Role,
    Guid WorkerId);