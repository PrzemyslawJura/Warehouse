using ErrorOr;
using MediatR;
using Warehouse.Domain.Warehouses;

namespace Warehouse.Application.Command.WarehouseRacks.UpdateWarehouseRack;
public record UpdateWarehouseRackCommand(
    Guid Id, int Sector, int Rack, int Quantity, Guid WarehouseSizeId) : IRequest<ErrorOr<WarehouseRack>>;
