using Inventory.Domain.AggregatesModel.OrderAggregate;
using Inventory.Domain.Events.Receipt;
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

    private void AddReceiptCreatedDomainEvent()
    {
        ReceiptCreatedDomainEvent receiptCreatedDomainEvent = new(OrderId, CreatedDate);

        AddDomainEvent(receiptCreatedDomainEvent);
    }
}
