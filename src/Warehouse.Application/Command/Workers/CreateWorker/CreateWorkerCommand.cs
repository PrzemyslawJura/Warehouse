using ErrorOr;
using MediatR;
using Warehouse.Domain.Workers;

namespace Warehouse.Application.Command.Workers.CreateWorker;
public record CreateWorkerCommand(
    string FirstName, string LastName, WorkerRole Role) : IRequest<ErrorOr<Worker>>;
