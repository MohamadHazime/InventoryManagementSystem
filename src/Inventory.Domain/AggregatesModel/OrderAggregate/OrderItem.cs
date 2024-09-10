using Inventory.Domain.Exceptions;
using Inventory.Domain.SeedWork;

namespace Inventory.Domain.AggregatesModel.OrderAggregate;

public class OrderItem : Entity
{
    public int ItemId { get; private set; }
    public int Quantity { get; private set; }
    public double UnitPrice { get; private set; }
    public double TotalPrice { get; private set; }

    public OrderItem(int itemId, int quantity, double unitPrice)
    {
        if (quantity <= 0)
        {
            throw new InvalidOrderItemQuantityException();
        }

        ItemId = itemId;
        Quantity = quantity;
        UnitPrice = unitPrice;
        TotalPrice = quantity * unitPrice;
    }

    public void IncreaseQuantity(int quantity)
    {
        if (quantity < 0)
        {
            throw new InvalidOrderItemQuantityException();
        }

        Quantity += quantity;
    }
}
