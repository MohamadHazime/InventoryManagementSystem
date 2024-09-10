using Inventory.Domain.AggregatesModel.ItemAggregate;
using Inventory.Domain.AggregatesModel.SupplierAggregate;
using Inventory.Domain.SeedWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure;

public class InventoryDbContext : DbContext, IUnitOfWork
{
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Item> Items { get; set; }

    private readonly IMediator _mediator;

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEventsAsync(this);
        await base.SaveChangesAsync(cancellationToken);

        return true;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData(
            new Item(1, "Item 1", "Description 1", 50, 10),
            new Item(2, "Item 2", "Description 2", 67, 10),
            new Item(3, "Item 3", "Description 3", 43, 10),
            new Item(4, "Item 4", "Description 4", 65, 10),
            new Item(5, "Item 5", "Description 5", 20, 10)
            );
    }
}
