using ErrorOr;
using MediatR;

namespace Warehouse.Application.Command.WarehousesSize.DeleteWarehouseSize;
public record DeleteWarehouseSizeCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;
