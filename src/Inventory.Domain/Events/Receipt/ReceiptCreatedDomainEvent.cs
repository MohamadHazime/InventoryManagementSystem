using Inventory.Domain.AggregatesModel.OrderAggregate;
using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Events.Receipt;

public class ReceiptCreatedDomainEvent : DomainEvent
{
    public int OrderId { get; private set; }
    public DateTime CreatedDate { get; private set; }

    public ReceiptCreatedDomainEvent(int orderId, DateTime createdDate) : base()
    {
        OrderId = orderId;
        CreatedDate = createdDate;
    }
}
