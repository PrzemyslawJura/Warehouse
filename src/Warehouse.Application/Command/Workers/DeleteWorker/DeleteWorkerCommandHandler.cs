using ErrorOr;
using MediatR;
using Warehouse.Application.Common;

namespace Warehouse.Application.Command.Workers.DeleteWorker;
public class DeleteWorkerCommandHandler : IRequestHandler<DeleteWorkerCommand, ErrorOr<Deleted>>
{
    private readonly IWorkersRepository _workersRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteWorkerCommandHandler(
        IWorkersRepository workersRepository,
        IUnitOfWork unitOfWork)
    {
        _workersRepository = workersRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteWorkerCommand command, CancellationToken cancellationToken)
    {
        var message = await _workersRepository.GetByIdAsync(command.Id);

        if (message is null)
        {
            return Error.NotFound(description: "Worker not found");
        }

        await _workersRepository.RemoveWorkerAsync(message);
        await _unitOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}
