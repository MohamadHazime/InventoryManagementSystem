using Inventory.Domain.AggregatesModel.ItemAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.EntityConfigurations;

public class ItemEntityTypeConfiguration : EntityTypeConfiguration<Item>
{
    public new virtual void Configure(EntityTypeBuilder<Item> itemConfiguration)
    {
        base.Configure(itemConfiguration);
    }
}
