using ErrorOr;
using MediatR;
using Warehouse.Domain.Warehouses;

namespace Warehouse.Application.Command.WarehouseRacks.CreateWarehouseRack;
public record CreateWarehouseRackCommand(
    int Sector, int Rack, int Quantity, Guid WarehouseSizeId) : IRequest<ErrorOr<WarehouseRack>>;
