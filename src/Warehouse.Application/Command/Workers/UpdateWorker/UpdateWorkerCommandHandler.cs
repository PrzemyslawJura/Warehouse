using ErrorOr;
using MediatR;
using Warehouse.Application.Common;
using Warehouse.Domain.Workers;

namespace Warehouse.Application.Command.Workers.UpdateWorker;
public class UpdateWorkerCommandHandler : IRequestHandler<UpdateWorkerCommand, ErrorOr<Worker>>
{
    private readonly IWorkersRepository _workersRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateWorkerCommandHandler(IWorkersRepository workersRepository, IUnitOfWork unitOfWork)
    {
        _workersRepository = workersRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Worker>> Handle(UpdateWorkerCommand request, CancellationToken cancellationToken)
    {
        var worker = new Worker(
            id: request.Id,
            firstName: request.FirstName,
            lastName: request.LastName,
            role: request.Role);

        await _workersRepository.UpdateWorkerAsync(worker);
        await _unitOfWork.CommitChangesAsync();

        return worker;
    }
}
