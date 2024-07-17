namespace Warehouse.Application.Common;
public interface IUnitOfWork
{
    Task CommitChangesAsync();
}
