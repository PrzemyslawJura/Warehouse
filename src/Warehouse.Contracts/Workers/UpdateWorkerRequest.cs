namespace Warehouse.Contracts.Workers;
public record UpdateWorkerRequest(Guid Id, string FirstName, string LastName, WorkerRole Role);
