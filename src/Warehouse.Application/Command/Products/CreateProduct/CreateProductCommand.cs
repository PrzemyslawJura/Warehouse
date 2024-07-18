using ErrorOr;
using MediatR;
using Warehouse.Domain.Products;

namespace Warehouse.Application.Command.Products.CreateProduct;
public record CreateProductCommand(
    string Name, ProductType Type, string Description) : IRequest<ErrorOr<Product>>;