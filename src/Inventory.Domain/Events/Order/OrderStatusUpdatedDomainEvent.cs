using Inventory.Domain.AggregatesModel.OrderAggregate;
using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Events;

public class OrderStatusUpdatedDomainEvent : DomainEvent
{
    public int OrderId { get; private set; }
    public OrderStatus Status { get; private set; }

    public OrderStatusUpdatedDomainEvent(int orderId, OrderStatus status) : base()
    {
        OrderId = orderId;
        Status = status;
    }
}
