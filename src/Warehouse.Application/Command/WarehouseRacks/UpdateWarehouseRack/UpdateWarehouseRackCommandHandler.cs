using ErrorOr;
using MediatR;
using Warehouse.Application.Common;
using Warehouse.Domain.Warehouses;

namespace Warehouse.Application.Command.WarehouseRacks.UpdateWarehouseRack;
public class UpdateWarehouseRackCommandHandler : IRequestHandler<UpdateWarehouseRackCommand, ErrorOr<WarehouseRack>>
{
    private readonly IWarehouseRacksRepository _warehouseRacksRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateWarehouseRackCommandHandler(IWarehouseRacksRepository warehouseRacksRepository, IUnitOfWork unitOfWork)
    {
        _warehouseRacksRepository = warehouseRacksRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<WarehouseRack>> Handle(UpdateWarehouseRackCommand request, CancellationToken cancellationToken)
    {
        var worker = new WarehouseRack(
            id: request.Id,
            sector: request.Sector,
            rack: request.Rack,
            quantity: request.Quantity,
            warehouseSizeId: request.WarehouseSizeId);

        await _warehouseRacksRepository.UpdateWarehouseRackAsync(worker);
        await _unitOfWork.CommitChangesAsync();

        return worker;
    }
}
