using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Products;

namespace Warehouse.Infrastructure.Products;
public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(50);

        builder.Property(x => x.Description)
            .HasMaxLength(250);

        builder.Property(x => x.Type)
            .HasConversion<string>();
    }
}
