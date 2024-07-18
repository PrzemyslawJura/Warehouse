using ErrorOr;
using MediatR;

namespace Warehouse.Application.Command.Products.DeleteProduct;
public record DeleteProductCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;
