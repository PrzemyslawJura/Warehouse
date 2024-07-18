using ErrorOr;
using MediatR;
using Warehouse.Application.Common;

namespace Warehouse.Application.Command.Products.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ErrorOr<Deleted>>
{
    private readonly IProductsRepository _productsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IProductsRepository productsRepository, IUnitOfWork unitOfWork)
    {
        _productsRepository = productsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _productsRepository.GetByIdAsync(command.Id);

        if (product is null)
        {
            return Error.NotFound(description: "Product not found");
        }

        await _productsRepository.RemoveProductAsync(product);
        await _unitOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}
