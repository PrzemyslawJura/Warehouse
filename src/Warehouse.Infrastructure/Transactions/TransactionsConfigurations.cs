using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Transactions;

namespace Warehouse.Infrastructure.Products;
public class TransactionConfigurations : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Type)
            .HasConversion<string>();

        builder.HasOne(x => x.Products)
              .WithMany(x => x.Transactions)
              .HasForeignKey(x => x.ProductId);

        builder.HasOne(x => x.WarehouseRacks)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.WarehouseRackId);

        builder.HasOne(x => x.Workers)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.WorkerId);
    }

}
