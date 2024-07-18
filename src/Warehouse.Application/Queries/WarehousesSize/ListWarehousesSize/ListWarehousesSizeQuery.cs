using ErrorOr;
using MediatR;
using Warehouse.Domain.WarehousesSize;

namespace Warehouse.Application.Queries.WarehousesSize.ListWarehousesSize;
public record ListWarehousesSizeQuery() : IRequest<ErrorOr<List<WarehouseSize?>>>;
