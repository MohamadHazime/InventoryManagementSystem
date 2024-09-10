using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Events;

public class ItemQuantityUpdatedDomainEvent : DomainEvent
{
    public int Quantity { get; private set; }

    public ItemQuantityUpdatedDomainEvent(int quantity) : base()
    {
        Quantity = quantity;
    }
}
