using Inventory.Domain.AggregatesModel.ReceiptAggregate;
using Inventory.Domain.SeedWork;

namespace Inventory.Infrastructure.Repositories;

public class ReceiptRepository : IReceiptRepository
{
    private readonly InventoryDbContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public ReceiptRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public Receipt Add(Receipt receipt)
    {
        return _context.Receipts.Add(receipt).Entity;
    }

    public async Task<Receipt> GetAsync(int receiptId)
    {
        Receipt receipt = await _context.Receipts.FindAsync(receiptId);

        if (receipt != null)
        {
            await _context.Entry(receipt).Collection(o => o.ReceiptItems).LoadAsync();
        }

        return receipt;
    }

    public void Update(Receipt receipt)
    {
        _context.Receipts.Update(receipt);
    }

    public async Task<bool> DeleteAsync(int receiptId)
    {
        Receipt receipt = await GetAsync(receiptId);

        if (receipt != null)
        {
            _context.Receipts.Remove(receipt);

            return true;
        }

        return false;
    }
}
