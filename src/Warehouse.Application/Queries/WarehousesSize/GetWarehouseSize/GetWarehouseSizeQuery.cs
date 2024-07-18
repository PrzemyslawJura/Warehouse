using ErrorOr;
using MediatR;
using Warehouse.Domain.WarehousesSize;

namespace Warehouse.Application.Queries.WarehousesSize.GetWarehouseSize;
public record GetWarehouseSizeQuery(Guid Id)
    : IRequest<ErrorOr<WarehouseSize>>;
