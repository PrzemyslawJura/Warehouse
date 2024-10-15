using ErrorOr;
using MediatR;
using Warehouse.Application.Common;

namespace Warehouse.Application.Command.WarehouseRacks.DeleteWarehouseRack;
public class DeleteWarehouseRackCommandHandler : IRequestHandler<DeleteWarehouseRackCommand, ErrorOr<Deleted>>
{
    private readonly IWarehouseRacksRepository _warehouseRacksRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteWarehouseRackCommandHandler(IWarehouseRacksRepository warehouseRacksRepository, IUnitOfWork unitOfWork)
    {
        _warehouseRacksRepository = warehouseRacksRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteWarehouseRackCommand command, CancellationToken cancellationToken)
    {
        var warehouseRack = await _warehouseRacksRepository.GetByIdAsync(command.Id);

        if (warehouseRack is null)
        {
            return Error.NotFound(description: "WarehouseRack not found");
        }

        await _warehouseRacksRepository.RemoveWarehouseRackAsync(warehouseRack);
        await _unitOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}

