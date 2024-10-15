using ErrorOr;
using MediatR;
using Warehouse.Domain.Warehouses;

namespace Warehouse.Application.Queries.WarehouseRacks.ListWarehouseRacks;
public record ListWarehouseRacksQuery() : IRequest<ErrorOr<List<WarehouseRack?>>>;
