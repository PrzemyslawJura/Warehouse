using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.WarehousesSize;

namespace Warehouse.Infrastructure.Products;
public class WarehouseSizeConfigurations : IEntityTypeConfiguration<WarehouseSize>
{
    public void Configure(EntityTypeBuilder<WarehouseSize> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();
    }
}
