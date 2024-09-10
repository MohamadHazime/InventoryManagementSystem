using Inventory.Domain.AggregatesModel.ItemAggregate;
using Inventory.Domain.SeedWork;

namespace Inventory.Infrastructure.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly InventoryDbContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public ItemRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public Item Add(Item item)
    {
        return _context.Items.Add(item).Entity;
    }

    public async Task<Item> GetAsync(int itemId)
    {
        return await _context.Items.FindAsync(itemId);
    }

    public void Update(Item item)
    {
        _context.Items.Update(item);
    }

    public async Task<bool> DeleteAsync(int itemId)
    {
        Item item = await GetAsync(itemId);

        if (item != null)
        {
            _context.Items.Remove(item);

            return true;
        }

        return false;
    }
}
