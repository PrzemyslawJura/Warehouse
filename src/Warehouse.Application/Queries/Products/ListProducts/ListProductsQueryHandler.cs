using ErrorOr;
using MediatR;
using Warehouse.Application.Common;
using Warehouse.Domain.Products;

namespace Warehouse.Application.Queries.Products.ListProducts;
public class ListProductsQueryHandler : IRequestHandler<ListProductsQuery, ErrorOr<List<Product?>>>
{
    private readonly IProductsRepository _productsRepository;

    public ListProductsQueryHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<ErrorOr<List<Product?>>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        var result = _productsRepository.ListAsync();

        if (!result.Result.Any())
        {
            return Error.NotFound(description: "Products not found");
        }

        return await result;
    }
}