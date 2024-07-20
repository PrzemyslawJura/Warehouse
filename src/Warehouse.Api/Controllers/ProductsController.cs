using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Command.Products.CreateProduct;
using Warehouse.Application.Command.Products.DeleteProduct;
using Warehouse.Application.Command.Products.UpdateProduct;
using Warehouse.Application.Queries.Products.GetProduct;
using Warehouse.Application.Queries.Products.ListProducts;
using Warehouse.Contracts.Products;

namespace Warehouse.Api.Controllers;
[Route("[controller]")]
[ApiController]
public class ProductsController : ApiController
{
    private readonly ISender _mediator;

    public ProductsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(
CreateProductRequest request)
    {
        var _productType = ToDto(request.Type);

        var command = new CreateProductCommand(
                            request.Name,
                            _productType,
                            request.Description);

        var createProductResult = await _mediator.Send(command);

        return createProductResult.Match(
            product => CreatedAtAction(
                nameof(GetProduct),
                new { ProductId = product.Id },
                new ProductResponse(
                    product.Id,
                    product.Name,
                    product.Type.ToString(),
                    product.Description)),
            Problem);
    }

    [HttpGet("{ProductId:guid}")]
    public async Task<IActionResult> GetProduct(Guid ProductId)
    {
        var query = new GetProductQuery(ProductId);

        var getProductResult = await _mediator.Send(query);

        return getProductResult.Match(
            product => Ok(new ProductResponse(
                product.Id,
                product.Name,
                product.Type.ToString(),
                product.Description)),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> ListProducts()
    {
        var command = new ListProductsQuery();

        var listProductsResult = await _mediator.Send(command);

        return listProductsResult.Match(
            products => Ok(products.ConvertAll(product => new ProductResponse(
                product.Id,
                product.Name,
                product.Type.ToString(),
                product.Description))),
            Problem);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductRequest request)
    {
        var _productType = ToDto(request.Type);

        var command = new UpdateProductCommand(
                            request.Id,
                            request.Name,
                            _productType,
                            request.Description);

        var updateProductResult = await _mediator.Send(command);

        return updateProductResult.Match(
                product => Ok(new ProductResponse(
                    product.Id,
                    product.Name,
                    product.Type.ToString(),
                    product.Description)),
            Problem);
    }

    [HttpDelete("{ProductId:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid ProductId)
    {
        var command = new DeleteProductCommand(ProductId);

        var deleteProductResult = await _mediator.Send(command);

        return deleteProductResult.Match(
            _ => NoContent(),
            Problem);
    }
    private static Domain.Products.ProductType ToDto(Contracts.Products.ProductType productType)
    {
        return productType switch
        {
            Contracts.Products.ProductType.One => Domain.Products.ProductType.One,
            Contracts.Products.ProductType.Two => Domain.Products.ProductType.Two,
            Contracts.Products.ProductType.Three => Domain.Products.ProductType.Three,
            _ => throw new InvalidOperationException(),
        };
    }
}
