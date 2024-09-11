using Inventory.Domain.AggregatesModel.ItemLedgerAggregate;
using Inventory.Domain.SeedWork;

namespace Inventory.Infrastructure.Repositories;

public class ItemLedgerRepository : IItemLedgerRepository
{
    private readonly InventoryDbContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public ItemLedgerRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public ItemLedger Add(ItemLedger item)
    {
        return _context.ItemLedgers.Add(item).Entity;
    }

    public async Task<ItemLedger> GetAsync(int itemId)
    {
        return await _context.ItemLedgers.FindAsync(itemId);
    }

    public void Update(ItemLedger item)
    {
        _context.ItemLedgers.Update(item);
    }

    public async Task<bool> DeleteAsync(int itemId)
    {
        ItemLedger item = await GetAsync(itemId);

        if (item != null)
        {
            _context.ItemLedgers.Remove(item);

            return true;
        }

        return false;
    }
}
