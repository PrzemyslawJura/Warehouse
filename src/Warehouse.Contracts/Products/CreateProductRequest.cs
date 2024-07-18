namespace Warehouse.Contracts.Products;
public record CreateProductRequest(string Name, ProductType Type, string Description);
