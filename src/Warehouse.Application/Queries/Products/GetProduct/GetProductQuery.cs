using ErrorOr;
using MediatR;
using Warehouse.Domain.Products;

namespace Warehouse.Application.Queries.Products.GetProduct;
public record GetProductQuery(Guid Id)
    : IRequest<ErrorOr<Product>>;