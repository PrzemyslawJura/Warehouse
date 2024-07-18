using System.Text.Json.Serialization;

namespace Warehouse.Contracts.Workers;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WorkerRole
{
    Admin,
    Regular
}