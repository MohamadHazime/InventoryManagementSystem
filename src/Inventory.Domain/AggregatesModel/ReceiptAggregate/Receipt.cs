using Inventory.Domain.AggregatesModel.OrderAggregate;
using Inventory.Domain.Events.Receipt;
using Inventory.Domain.Exceptions;
using Inventory.Domain.SeedWork;

namespace Inventory.Domain.AggregatesModel.ReceiptAggregate;

public class Receipt : Entity, IAggregateRoot
{
    public int OrderId { get; private set; }
    public Order Order { get; }
    public DateTime CreatedDate { get; private set; }
    public IReadOnlyCollection<ReceiptItem> ReceiptItems => _receiptItems.AsReadOnly();

    private readonly List<ReceiptItem> _receiptItems;

    public Receipt(int orderId)
    {
        OrderId = orderId;
        _receiptItems = new();

        AddReceiptCreatedDomainEvent();
    }

    public void AddReceiptItem(int itemId, int quantityReceived, int quantity)
    {
        if (quantityReceived > quantity)
        {
            throw new InvalidReceiptItemQuantityReceivedException();
        }

        var existingItemInReceipt = _receiptItems.SingleOrDefault(o => o.ItemId == itemId);

        if (existingItemInReceipt != null)
        {
            existingItemInReceipt.IncreaseQuantityReceived(quantityReceived, quantity);
        }
        else
        {
            var receiptItem = new ReceiptItem(itemId, quantityReceived);
            _receiptItems.Add(receiptItem);
        }
    }

    private void AddReceiptCreatedDomainEvent()
    {
        ReceiptCreatedDomainEvent receiptCreatedDomainEvent = new(OrderId, CreatedDate);

        AddDomainEvent(receiptCreatedDomainEvent);
    }
}
