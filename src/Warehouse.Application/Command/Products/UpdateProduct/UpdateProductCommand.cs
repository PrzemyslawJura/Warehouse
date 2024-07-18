using ErrorOr;
using MediatR;
using Warehouse.Domain.Products;

namespace Warehouse.Application.Command.Products.UpdateProduct;
public record UpdateProductCommand(
    Guid Id, string Name, ProductType Type, string Description) : IRequest<ErrorOr<Product>>;
