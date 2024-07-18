using ErrorOr;
using MediatR;
using Warehouse.Domain.WarehousesSize;

namespace Warehouse.Application.Command.WarehousesSize.CreateWarehouseSize;
public record CreateWarehouseSizeCommand(
    int SectorNumber, int RackQuantity) : IRequest<ErrorOr<WarehouseSize>>;
