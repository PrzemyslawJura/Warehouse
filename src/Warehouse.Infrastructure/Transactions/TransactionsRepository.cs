using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Common;
using Warehouse.Domain.Transactions;
using Warehouse.Infrastructure.Common;

namespace Warehouse.Infrastructure.Products;
public class TransactionsRepository : ITransactionsRepository
{
    private readonly WarehouseDbContext _dbContext;

    public TransactionsRepository(WarehouseDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddTransactionAsync(Transaction transaction)
    {
        await _dbContext.Transactions.AddAsync(transaction);
    }

    public async Task<Transaction?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Transactions.FirstOrDefaultAsync(transaction => transaction.Id == id);
    }

    public async Task<List<Transaction>> ListAsync()
    {
        return await _dbContext.Transactions.ToListAsync();
    }

    public Task RemoveTransactionAsync(Transaction transaction)
    {
        _dbContext.Remove(transaction);

        return Task.CompletedTask;
    }

    public Task UpdateTransactionAsync(Transaction transaction)
    {
        _dbContext.Update(transaction);

        return Task.CompletedTask;
    }
}
