using Warehouse.Domain.Workers;

namespace Warehouse.Application.Common;
public interface IWorkersRepository
{
    Task AddWorkerAsync(Worker worker);
    Task<Worker?> GetByIdAsync(Guid id);
    Task<List<Worker>> ListAsync();
    Task UpdateWorkerAsync(Worker worker);
    Task RemoveWorkerAsync(Worker worker);
}
