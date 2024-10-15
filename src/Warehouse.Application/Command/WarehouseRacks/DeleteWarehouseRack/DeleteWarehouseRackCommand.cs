using ErrorOr;
using MediatR;

namespace Warehouse.Application.Command.WarehouseRacks.DeleteWarehouseRack;
public record DeleteWarehouseRackCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;
