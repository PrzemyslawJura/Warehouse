using Warehouse.Domain.Transactions;

namespace Warehouse.Domain.Workers;
public class Worker
{
    Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public WorkerRole Role { get; set; }

    public ICollection<Transaction>? Transactions { get; private set; }

    public Worker(
        string firstName,
        string lastName,
        WorkerRole role,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Role = role;
    }

    public Worker() { }
}
