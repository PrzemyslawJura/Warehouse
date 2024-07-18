using ErrorOr;
using MediatR;
using Warehouse.Application.Common;

namespace Warehouse.Application.Command.WarehousesSize.DeleteWarehouseSize;
public class DeleteWarehouseSizeCommandHandler : IRequestHandler<DeleteWarehouseSizeCommand, ErrorOr<Deleted>>
{
    private readonly IWarehousesSizeRepository _warehousesSizeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteWarehouseSizeCommandHandler(IWarehousesSizeRepository warehousesSizeRepository, IUnitOfWork unitOfWork)
    {
        _warehousesSizeRepository = warehousesSizeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteWarehouseSizeCommand command, CancellationToken cancellationToken)
    {
        var warehouseSize = await _warehousesSizeRepository.GetByIdAsync(command.Id);

        if (warehouseSize is null)
        {
            return Error.NotFound(description: "WarehouseSize not found");
        }

        await _warehousesSizeRepository.RemoveWarehouseSizeAsync(warehouseSize);
        await _unitOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}

