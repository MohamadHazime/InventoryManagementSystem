using Inventory.Domain.AggregatesModel.ItemLedgerAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.EntityConfigurations;

public class ItemLedgerEntityTypeConfiguration : EntityTypeConfiguration<ItemLedger>
{
    public new virtual void Configure(EntityTypeBuilder<ItemLedger> itemLedgerConfiguration)
    {
        base.Configure(itemLedgerConfiguration);

        itemLedgerConfiguration
            .Property(il => il.Type)
            .HasConversion<string>()
            .HasMaxLength(30);

        itemLedgerConfiguration.HasOne(il => il.Item)
            .WithMany()
            .HasForeignKey(il => il.ItemId);
    }
}
