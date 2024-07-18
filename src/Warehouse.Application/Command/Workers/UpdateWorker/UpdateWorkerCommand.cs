using ErrorOr;
using MediatR;
using Warehouse.Domain.Workers;

namespace Warehouse.Application.Command.Workers.UpdateWorker;
public record UpdateWorkerCommand(
    Guid Id, string FirstName, string LastName, WorkerRole Role) : IRequest<ErrorOr<Worker>>;
