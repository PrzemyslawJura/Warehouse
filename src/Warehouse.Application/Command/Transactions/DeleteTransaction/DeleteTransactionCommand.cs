using ErrorOr;
using MediatR;

namespace Warehouse.Application.Command.Transactions.DeleteTransactionCommand;
public record DeleteTransactionCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;