using ErrorOr;
using MediatR;
using Warehouse.Application.Common;
using Warehouse.Domain.WarehousesSize;

namespace Warehouse.Application.Command.WarehousesSize.UpdateWarehouseSize;
public class UpdateWarehouseSizeCommandHandler : IRequestHandler<UpdateWarehouseSizeCommand, ErrorOr<WarehouseSize>>
{
    private readonly IWarehousesSizeRepository _warehousesSizeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateWarehouseSizeCommandHandler(IWarehousesSizeRepository warehousesSizeRepository, IUnitOfWork unitOfWork)
    {
        _warehousesSizeRepository = warehousesSizeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<WarehouseSize>> Handle(UpdateWarehouseSizeCommand request, CancellationToken cancellationToken)
    {
        var worker = new WarehouseSize(
            id: request.Id,
            sectorNumber: request.SectorNumber,
            rackQuantity: request.RackQuantity);

        await _warehousesSizeRepository.UpdateWarehouseSizeAsync(worker);
        await _unitOfWork.CommitChangesAsync();

        return worker;
    }
}
