using ErrorOr;
using MediatR;

namespace Warehouse.Application.Command.Workers.DeleteWorker;
public record DeleteWorkerCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;
