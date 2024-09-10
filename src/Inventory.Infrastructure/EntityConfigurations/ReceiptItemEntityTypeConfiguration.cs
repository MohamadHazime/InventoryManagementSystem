using Inventory.Domain.AggregatesModel.ReceiptAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.EntityConfigurations;

public class ReceiptItemEntityTypeConfiguration : EntityTypeConfiguration<ReceiptItem>
{
    public new virtual void Configure(EntityTypeBuilder<ReceiptItem> receiptItemConfiguration)
    {
        base.Configure(receiptItemConfiguration);

        receiptItemConfiguration.Property<int>("ReceiptId");

        receiptItemConfiguration.HasOne(ri => ri.Item)
                .WithMany()
                .HasForeignKey(ri => ri.ItemId);
    }
}
