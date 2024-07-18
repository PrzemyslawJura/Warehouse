using ErrorOr;
using MediatR;
using Warehouse.Application.Common;
using Warehouse.Domain.WarehousesSize;

namespace Warehouse.Application.Command.WarehousesSize.CreateWarehouseSize;

public class CreateWarehouseSizeCommandHandler : IRequestHandler<CreateWarehouseSizeCommand, ErrorOr<WarehouseSize>>
{
    private readonly IWarehousesSizeRepository _warehousesSizeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateWarehouseSizeCommandHandler(IWarehousesSizeRepository warehousesSizeRepository, IUnitOfWork unitOfWork)
    {
        _warehousesSizeRepository = warehousesSizeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<WarehouseSize>> Handle(CreateWarehouseSizeCommand request, CancellationToken cancellationToken)
    {
        var warehouseSize = new WarehouseSize(
            request.Name,
            sectorNumber: request.SectorNumber,
            rackQuantity: request.RackQuantity);

        await _warehousesSizeRepository.AddWarehouseSizeAsync(warehouseSize);
        await _unitOfWork.CommitChangesAsync();

        return warehouseSize;
    }
}
