﻿using ErrorOr;
using MediatR;
using Warehouse.Application.Common;
using Warehouse.Domain.Products;

namespace Warehouse.Application.Command.Products.CreateProduct;
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<Product>>
{
    private readonly IProductsRepository _productsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IProductsRepository productsRepository, IUnitOfWork unitOfWork)
    {
        _productsRepository = productsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(
            name: request.Name,
            type: request.Type,
            description: request.Description);

        await _productsRepository.AddProductAsync(product);
        await _unitOfWork.CommitChangesAsync();

        return product;
    }
}
