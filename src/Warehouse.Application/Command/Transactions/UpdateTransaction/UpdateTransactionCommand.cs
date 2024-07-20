using ErrorOr;
using MediatR;
using Warehouse.Domain.Transactions;

namespace Warehouse.Application.Command.Transactions.UpdateTransactionCommand;
public record UpdateTransactionCommand(
    Guid TransactionId,
    Guid ProductId,
    int TransactionQuantity,
    TransactionType TransactionType,
    DateTime Date,
    Guid WarehouseSizeId,
    Guid WarehouseRackId,
    int Sector,
    int Rack,
    Guid WorkerId) : IRequest<ErrorOr<Transaction>>;
