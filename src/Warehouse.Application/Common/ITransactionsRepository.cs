using Warehouse.Domain.Transactions;

namespace Warehouse.Application.Common;
public interface ITransactionsRepository
{
    Task AddTransactionAsync(Transaction transaction);
    Task<Transaction?> GetByIdAsync(Guid id);
    Task<List<Transaction>> ListAsync();
    Task UpdateTransactionAsync(Transaction transaction);
    Task RemoveTransactionAsync(Transaction transaction);
}
