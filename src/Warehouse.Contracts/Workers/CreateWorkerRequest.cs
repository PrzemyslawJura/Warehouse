namespace Warehouse.Contracts.Workers;

public record CreateWorkerRequest(string FirstName, string LastName, WorkerRole Role);