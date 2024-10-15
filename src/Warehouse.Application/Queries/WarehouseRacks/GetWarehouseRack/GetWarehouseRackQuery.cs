using ErrorOr;
using MediatR;
using Warehouse.Domain.Warehouses;

namespace Warehouse.Application.Queries.WarehouseRacks.GetWarehouseRack;
public record GetWarehouseRackQuery(Guid Id)
    : IRequest<ErrorOr<WarehouseRack>>;
