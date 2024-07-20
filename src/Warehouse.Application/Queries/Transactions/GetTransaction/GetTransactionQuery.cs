using ErrorOr;
using MediatR;
using Warehouse.Domain.Transactions;

namespace Warehouse.Application.Queries.Transactions.GetTransaction;
public record GetTransactionQuery(Guid Id)
    : IRequest<ErrorOr<Transaction>>;
