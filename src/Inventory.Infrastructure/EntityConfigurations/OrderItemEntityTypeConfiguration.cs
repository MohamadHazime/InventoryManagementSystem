using Inventory.Domain.AggregatesModel.OrderAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.EntityConfigurations;

public class OrderItemEntityTypeConfiguration : EntityTypeConfiguration<OrderItem>
{
    public new virtual void Configure(EntityTypeBuilder<OrderItem> orderItemConfiguration)
    {
        base.Configure(orderItemConfiguration);

        orderItemConfiguration.Property<int>("OrderId");

        orderItemConfiguration.HasOne(oi => oi.Item)
                .WithMany()
                .HasForeignKey(oi => oi.ItemId);
    }
}
