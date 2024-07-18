using ErrorOr;
using MediatR;
using Warehouse.Application.Common;
using Warehouse.Domain.Workers;

namespace Warehouse.Application.Queries.Workers.ListWorkers;
public class ListWorkersQueryHandler : IRequestHandler<ListWorkersQuery, ErrorOr<List<Worker?>>>
{
    private readonly IWorkersRepository _workersRepository;

    public ListWorkersQueryHandler(IWorkersRepository workersRepository)
    {
        _workersRepository = workersRepository;
    }

    public async Task<ErrorOr<List<Worker?>>> Handle(ListWorkersQuery request, CancellationToken cancellationToken)
    {
        var result = _workersRepository.ListAsync();

        if (!result.Result.Any())
        {
            return Error.NotFound(description: "Workers not found");
        }

        return await result;
    }
}
