using ErrorOr;
using MediatR;
using Warehouse.Domain.WarehousesSize;

namespace Warehouse.Application.Command.WarehousesSize.UpdateWarehouseSize;
public record UpdateWarehouseSizeCommand(
    Guid Id, int SectorNumber, int RackQuantity) : IRequest<ErrorOr<WarehouseSize>>;
