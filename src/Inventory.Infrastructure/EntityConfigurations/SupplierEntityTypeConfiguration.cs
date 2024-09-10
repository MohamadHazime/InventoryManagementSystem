using Inventory.Domain.AggregatesModel.SupplierAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.EntityConfigurations;

public class SupplierEntityTypeConfiguration : EntityTypeConfiguration<Supplier>
{
    public new virtual void Configure(EntityTypeBuilder<Supplier> supplierConfiguration)
    {
        base.Configure(supplierConfiguration);
    }
}
