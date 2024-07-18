using ErrorOr;
using MediatR;
using Warehouse.Domain.Workers;

namespace Warehouse.Application.Queries.Workers.ListWorkers;
public record ListWorkersQuery() : IRequest<ErrorOr<List<Worker?>>>;
