using ErrorOr;
using MediatR;
using Warehouse.Domain.Transactions;

namespace Warehouse.Application.Queries.Transactions.ListTransactions;
public record ListTransactionsQuery() : IRequest<ErrorOr<List<Transaction?>>>;
