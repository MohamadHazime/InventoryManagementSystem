using Inventory.Domain.AggregatesModel.OrderAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.EntityConfigurations;

public class OrderEntityTypeConfiguration : EntityTypeConfiguration<Order>
{
    public new virtual void Configure(EntityTypeBuilder<Order> orderConfiguration)
    {
        base.Configure(orderConfiguration);

        orderConfiguration
            .Property(o => o.Status)
            .HasConversion<string>()
            .HasMaxLength(30);

        orderConfiguration.HasOne(o => o.Supplier)
            .WithMany()
            .HasForeignKey(o => o.SupplierId);
    }
}
