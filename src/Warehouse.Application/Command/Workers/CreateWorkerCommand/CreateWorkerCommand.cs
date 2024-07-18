using ErrorOr;
using MediatR;
using Warehouse.Domain.Workers;

namespace Warehouse.Application.Command.Workers.CreateWorkerCommand;
public record CreateWorkerCommand(
    string FirstName, string LastName, WorkerRole Role) : IRequest<ErrorOr<Worker>>;
