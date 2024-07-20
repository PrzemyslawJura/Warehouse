using ErrorOr;
using MediatR;
using Warehouse.Domain.Transactions;

namespace Warehouse.Application.Command.Transactions.CreateTransactionCommand;
public record CreateTransactionCommand(
    Guid ProductId,
    int TransactionQuantity,
    TransactionType TransactionType,
    DateTime Date,
    Guid WarehouseSizeId,
    int Sector,
    int Rack,
    Guid WorkerId) : IRequest<ErrorOr<Transaction>>;
