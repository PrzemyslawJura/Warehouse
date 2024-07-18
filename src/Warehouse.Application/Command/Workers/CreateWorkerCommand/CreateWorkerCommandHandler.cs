using ErrorOr;
using MediatR;
using Warehouse.Application.Common;
using Warehouse.Domain.Workers;

namespace Warehouse.Application.Command.Workers.CreateWorkerCommand;
public class CreateWorkerCommandHandler : IRequestHandler<CreateWorkerCommand, ErrorOr<Worker>>
{
    private readonly IWorkersRepository _workersRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateWorkerCommandHandler(IWorkersRepository workersRepository, IUnitOfWork unitOfWork)
    {
        _workersRepository = workersRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Worker>> Handle(CreateWorkerCommand request, CancellationToken cancellationToken)
    {
        var worker = new Worker(
            firstName: request.FirstName,
            lastName: request.LastName,
            role: request.Role);

        await _workersRepository.AddWorkerAsync(worker);
        await _unitOfWork.CommitChangesAsync();

        return worker;
    }
}
