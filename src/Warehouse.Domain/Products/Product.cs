﻿using Warehouse.Domain.Transactions;

namespace Warehouse.Domain.Products;
public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ProductType Type { get; set; }
    public string Description { get; set; }

    public ICollection<Transaction>? Transactions { get; private set; }

    public Product(
        string name,
        ProductType type,
        string description,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Name = name;
        Type = type;
        Description = description;
    }

    private Product() { }
}