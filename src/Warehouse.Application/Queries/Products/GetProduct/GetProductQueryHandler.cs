using ErrorOr;
using MediatR;
using Warehouse.Application.Common;
using Warehouse.Domain.Products;

namespace Warehouse.Application.Queries.Products.GetProduct;
public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ErrorOr<Product>>
{
    private readonly IProductsRepository _productsRepository;

    public GetProductQueryHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<ErrorOr<Product>> Handle(GetProductQuery query, CancellationToken cancellationToken)
    {
        var product = await _productsRepository.GetByIdAsync(query.Id);

        return product is null
            ? Error.NotFound(description: "Product not found")
            : product;
    }
}
