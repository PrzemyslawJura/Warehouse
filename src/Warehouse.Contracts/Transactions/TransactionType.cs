using System.Text.Json.Serialization;

namespace Warehouse.Contracts.Transactions;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TransactionType
{
    In,
    Out
}