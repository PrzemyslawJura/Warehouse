using Warehouse.Domain.Products;

namespace Warehouse.Application.Common;
public interface IProductsRepository
{
    Task AddProductAsync(Product product);
    Task<Product?> GetByIdAsync(Guid id);
    Task<List<Product>> ListAsync();
    Task UpdateProductAsync(Product product);
    Task RemoveProductAsync(Product product);
}
