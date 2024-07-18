using ErrorOr;
using MediatR;
using Warehouse.Domain.Workers;

namespace Warehouse.Application.Queries.Workers.GetWorker;
public record GetWorkerQuery(Guid WorkerId)
    : IRequest<ErrorOr<Worker>>;