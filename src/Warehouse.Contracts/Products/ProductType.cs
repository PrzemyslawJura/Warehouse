using System.Text.Json.Serialization;

namespace Warehouse.Contracts.Products;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProductType
{
    One,
    Two,
    Three
}