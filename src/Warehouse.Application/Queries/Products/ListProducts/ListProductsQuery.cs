using ErrorOr;
using MediatR;
using Warehouse.Domain.Products;

namespace Warehouse.Application.Queries.Products.ListProducts;
public record ListProductsQuery() : IRequest<ErrorOr<List<Product?>>>;
