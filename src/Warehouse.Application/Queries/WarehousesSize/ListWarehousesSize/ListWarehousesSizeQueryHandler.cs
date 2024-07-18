using ErrorOr;
using MediatR;
using Warehouse.Application.Common;
using Warehouse.Domain.WarehousesSize;

namespace Warehouse.Application.Queries.WarehousesSize.ListWarehousesSize;
public class ListWarehousesSizeQueryHandler : IRequestHandler<ListWarehousesSizeQuery, ErrorOr<List<WarehouseSize?>>>
{
    private readonly IWarehousesSizeRepository _warehousesSizeRepository;

    public ListWarehousesSizeQueryHandler(IWarehousesSizeRepository warehousesSizeRepository)
    {
        _warehousesSizeRepository = warehousesSizeRepository;
    }

    public async Task<ErrorOr<List<WarehouseSize?>>> Handle(ListWarehousesSizeQuery request, CancellationToken cancellationToken)
    {
        var result = _warehousesSizeRepository.ListAsync();

        if (!result.Result.Any())
        {
            return Error.NotFound(description: "WarehouseSize not found");
        }

        return await result;
    }
}

