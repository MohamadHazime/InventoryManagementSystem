using Inventory.Domain.AggregatesModel.ReceiptAggregate;
using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Events.Receipt;

public class ReceiptCreatedDomainEvent : DomainEvent
{
    public int OrderId { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public IEnumerable<ReceiptItem> ReceiptItems { get; private set; }

    public ReceiptCreatedDomainEvent(int orderId, DateTime createdDate, IEnumerable<ReceiptItem> receiptItems) : base()
    {
        OrderId = orderId;
        CreatedDate = createdDate;
        ReceiptItems = receiptItems;
    }
}
