using Inventory.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.EntityConfigurations;

public abstract class EntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
{
    public void Configure(EntityTypeBuilder<T> entityConfiguration)
    {
        entityConfiguration.Ignore(b => b.DomainEvents);

        entityConfiguration.Property(o => o.Id)
            .UseHiLo("orderseq");
    }
}
