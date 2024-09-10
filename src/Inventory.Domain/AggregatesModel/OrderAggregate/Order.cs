using Inventory.Domain.AggregatesModel.SupplierAggregate;
using Inventory.Domain.Events;
using Inventory.Domain.SeedWork;

namespace Inventory.Domain.AggregatesModel.OrderAggregate;

public class Order : Entity, IAggregateRoot
{
    public int SupplierId { get; private set; }
    public Supplier Supplier { get; }
    public DateTime PurchaseDate { get; private set; }
    public double TotalAmount { get; private set; }
    public OrderStatus Status { get; private set; }
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

    private readonly List<OrderItem> _orderItems;

    public Order(int supplierId, DateTime purchaseDate)
    {
        SupplierId = supplierId;
        PurchaseDate = purchaseDate;
        Status = OrderStatus.Submitted;
        _orderItems = new();

        AddOrderPurchasedDomainEvent();
    }

    public void AddOrderItem(int itemId, int quantity, double unitPrice)
    {
        var existingItemInOrder = _orderItems.SingleOrDefault(o => o.ItemId == itemId);

        if (existingItemInOrder != null)
        {
            existingItemInOrder.IncreaseQuantity(quantity);
        }
        else
        {
            var orderItem = new OrderItem(itemId, quantity, unitPrice);
            _orderItems.Add(orderItem);
        }
    }

    public void CalculateTotalAmount()
    {
        foreach(OrderItem orderItem in _orderItems)
        {
            TotalAmount += orderItem.TotalPrice;
        }
    }

    public void UpdateOrderStatus(bool isCompleted)
    {
        Status = isCompleted ? OrderStatus.Completed : OrderStatus.Cancelled;

        AddOrderStatusUpdatedDomainEvent();
    }

    public bool IsFinalStatus()
    {
        return Status == OrderStatus.Completed || Status == OrderStatus.Cancelled;
    }

    private void AddOrderPurchasedDomainEvent()
    {
        OrderPurchasedDomainEvent orderPurchasedDomainEvent = new(SupplierId, PurchaseDate, Status);

        this.AddDomainEvent(orderPurchasedDomainEvent);
    }

    private void AddOrderStatusUpdatedDomainEvent()
    {
        OrderStatusUpdatedDomainEvent orderStatusUpdatedDomainEvent = new(Id, Status);

        this.AddDomainEvent(orderStatusUpdatedDomainEvent);
    }
}
 