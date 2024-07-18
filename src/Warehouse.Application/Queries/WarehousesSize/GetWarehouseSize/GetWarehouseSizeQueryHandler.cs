using ErrorOr;
using MediatR;
using Warehouse.Application.Common;
using Warehouse.Domain.WarehousesSize;

namespace Warehouse.Application.Queries.WarehousesSize.GetWarehouseSize;
public class GetWarehouseSizeQueryHandler : IRequestHandler<GetWarehouseSizeQuery, ErrorOr<WarehouseSize>>
{
    private readonly IWarehousesSizeRepository _warehousesSizeRepository;

    public GetWarehouseSizeQueryHandler(IWarehousesSizeRepository warehousesSizeRepository)
    {
        _warehousesSizeRepository = warehousesSizeRepository;
    }

    public async Task<ErrorOr<WarehouseSize>> Handle(GetWarehouseSizeQuery query, CancellationToken cancellationToken)
    {
        var warehouseSize = await _warehousesSizeRepository.GetByIdAsync(query.Id);

        return warehouseSize is null
            ? Error.NotFound(description: "WarehouseSize not found")
            : warehouseSize;
    }
}
