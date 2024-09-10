using Inventory.Domain.AggregatesModel.ReceiptAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.EntityConfigurations;

public class ReceiptEntityTypeConfiguration : EntityTypeConfiguration<Receipt>
{
    public new virtual void Configure(EntityTypeBuilder<Receipt> receiptConfiguration)
    {
        base.Configure(receiptConfiguration);

        receiptConfiguration.HasOne(r => r.Order)
            .WithOne(o => o.Receipt)
            .HasForeignKey<Receipt>(r => r.OrderId);
    }
}
