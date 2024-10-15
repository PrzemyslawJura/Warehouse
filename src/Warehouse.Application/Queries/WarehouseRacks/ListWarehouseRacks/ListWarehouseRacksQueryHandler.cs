using ErrorOr;
using MediatR;
using Warehouse.Application.Common;
using Warehouse.Domain.Warehouses;

namespace Warehouse.Application.Queries.WarehouseRacks.ListWarehouseRacks;
public class ListWarehouseRacksQueryHandler : IRequestHandler<ListWarehouseRacksQuery, ErrorOr<List<WarehouseRack?>>>
{
    private readonly IWarehouseRacksRepository _warehouseRacksRepository;

    public ListWarehouseRacksQueryHandler(IWarehouseRacksRepository warehousesRackRepository)
    {
        _warehouseRacksRepository = warehousesRackRepository;
    }

    public async Task<ErrorOr<List<WarehouseRack?>>> Handle(ListWarehouseRacksQuery request, CancellationToken cancellationToken)
    {
        var result = _warehouseRacksRepository.ListAsync();

        if (!result.Result.Any())
        {
            return Error.NotFound(description: "Warehouse Racks not found");
        }

        return await result;
    }
}

