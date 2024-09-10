using Inventory.Domain.Events;
using Inventory.Domain.SeedWork;

namespace Inventory.Domain.AggregatesModel.ItemAggregate;

public class Item : Entity, IAggregateRoot
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public double Price { get; private set; }
    public int Quantity { get; private set; }

    public Item(int id, string name, string description, double price, int quantity)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
    }

    public void UpdateQuantity(int quantity)
    {
        Quantity += quantity;

        AddItemQuantityUpdatedDomainEvent(quantity);
    }

    private void AddItemQuantityUpdatedDomainEvent(int quantity)
    {
        ItemQuantityUpdatedDomainEvent itemQuantityUpdatedDomainEvent = new(Id, quantity);

        AddDomainEvent(itemQuantityUpdatedDomainEvent);
    }
}
