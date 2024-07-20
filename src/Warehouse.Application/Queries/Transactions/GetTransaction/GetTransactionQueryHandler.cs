using ErrorOr;
using MediatR;
using Warehouse.Application.Common;
using Warehouse.Domain.Transactions;

namespace Warehouse.Application.Queries.Transactions.GetTransaction;
public class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, ErrorOr<Transaction>>
{
    private readonly ITransactionsRepository _transactionsRepository;

    public GetTransactionQueryHandler(ITransactionsRepository transactionsRepository)
    {
        _transactionsRepository = transactionsRepository;
    }

    public async Task<ErrorOr<Transaction>> Handle(GetTransactionQuery query, CancellationToken cancellationToken)
    {
        var transaction = await _transactionsRepository.GetByIdAsync(query.Id);

        return transaction is null
            ? Error.NotFound(description: "Worker not found")
            : transaction;
    }
}
