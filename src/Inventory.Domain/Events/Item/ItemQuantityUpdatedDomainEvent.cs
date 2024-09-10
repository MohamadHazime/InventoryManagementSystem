using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Events;

public class ItemQuantityUpdatedDomainEvent : DomainEvent
{
    public int ItemId { get; private set; }
    public int Quantity { get; private set; }

    public ItemQuantityUpdatedDomainEvent(int itemId, int quantity) : base()
    {
        ItemId = itemId;
        Quantity = quantity;
    }
}
