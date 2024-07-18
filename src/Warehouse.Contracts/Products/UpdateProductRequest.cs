namespace Warehouse.Contracts.Products;
public record UpdateProductRequest(Guid Id, string Name, ProductType Type, string Description);
