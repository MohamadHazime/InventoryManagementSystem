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

    public Order(int supplierId, DateTime purchaseDate, double totalAmount, OrderStatus status)
    {
        SupplierId = supplierId;
        PurchaseDate = purchaseDate;
        TotalAmount = totalAmount;
        Status = status;

        AddOrderPurchasedDomainEvent(supplierId, purchaseDate, totalAmount, status);
    }

    private void AddOrderPurchasedDomainEvent(int supplierId, DateTime purchaseDate, double totalAmount, OrderStatus status)
    {
        OrderPurchasedDomainEvent orderPurchasedDomainEvent = new(supplierId, purchaseDate, totalAmount, status);

        this.AddDomainEvent(orderPurchasedDomainEvent);
    }
}
