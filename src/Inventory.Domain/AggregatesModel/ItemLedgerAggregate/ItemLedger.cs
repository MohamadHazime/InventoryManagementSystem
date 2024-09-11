using Inventory.Domain.AggregatesModel.ItemAggregate;
using Inventory.Domain.SeedWork;

namespace Inventory.Domain.AggregatesModel.ItemLedgerAggregate;

public class ItemLedger : Entity, IAggregateRoot
{
    public int ItemId { get; private set; }
    public Item Item { get; private set; }
    public int Quantity { get; private set; }
    public ItemLedgerType Type { get; private set; }
    public int ReferenceId { get; private set; }
    public DateTime CreatedDate { get; private set; }

    public ItemLedger(int itemId, int quantity, ItemLedgerType type, int referenceId)
    {
        ItemId = itemId;
        Quantity = quantity;
        Type = type;
        ReferenceId = referenceId;
        CreatedDate = DateTime.UtcNow;
    }
}
