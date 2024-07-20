using ErrorOr;
using MediatR;
using Warehouse.Application.Common;
using Warehouse.Domain.Transactions;

namespace Warehouse.Application.Queries.Transactions.ListTransactions;


public class ListTransactionsQueryHandler : IRequestHandler<ListTransactionsQuery, ErrorOr<List<Transaction?>>>
{
    private readonly ITransactionsRepository _transactionsRepository;

    public ListTransactionsQueryHandler(ITransactionsRepository transactionsRepository)
    {
        _transactionsRepository = transactionsRepository;
    }

    public async Task<ErrorOr<List<Transaction?>>> Handle(ListTransactionsQuery request, CancellationToken cancellationToken)
    {
        var result = _transactionsRepository.ListAsync();

        if (!result.Result.Any())
        {
            return Error.NotFound(description: "Transactions not found");
        }

        return await result;
    }
}
