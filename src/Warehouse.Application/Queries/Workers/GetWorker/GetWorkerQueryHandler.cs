using ErrorOr;
using MediatR;
using Warehouse.Application.Common;
using Warehouse.Domain.Workers;

namespace Warehouse.Application.Queries.Workers.GetWorker;
public class GetWorkerQueryHandler : IRequestHandler<GetWorkerQuery, ErrorOr<Worker>>
{
    private readonly IWorkersRepository _workersRepository;

    public GetWorkerQueryHandler(IWorkersRepository workersRepository)
    {
        _workersRepository = workersRepository;
    }

    public async Task<ErrorOr<Worker>> Handle(GetWorkerQuery query, CancellationToken cancellationToken)
    {
        var worker = await _workersRepository.GetByIdAsync(query.WorkerId);

        return worker is null
            ? Error.NotFound(description: "Worker not found")
            : worker;
    }
}
