using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Warehouses;

namespace Warehouse.Infrastructure.Products;
public class WarehouseRackConfigurations : IEntityTypeConfiguration<WarehouseRack>
{
    public void Configure(EntityTypeBuilder<WarehouseRack> builder)
    {
        builder.HasOne(x => x.WarehousesSize)
            .WithMany(x => x.WarehousesRack)
            .HasForeignKey(x => x.WarehouseSizeId);
    }
}
