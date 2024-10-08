﻿using Inventory.Domain.AggregatesModel.ReceiptAggregate;
using Inventory.Domain.AggregatesModel.SupplierAggregate;
using Inventory.Domain.Events;
using Inventory.Domain.SeedWork;

namespace Inventory.Domain.AggregatesModel.OrderAggregate;

public class Order : Entity, IAggregateRoot
{
    public int SupplierId { get; private set; }
    public Supplier Supplier { get; private set; }
    public Receipt Receipt { get; }
    public DateTime PurchaseDate { get; private set; }
    public double TotalAmount { get; private set; }
    public OrderStatus Status { get; private set; }
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

    private readonly List<OrderItem> _orderItems;

    public Order(int supplierId)
    {
        SupplierId = supplierId;
        PurchaseDate = DateTime.UtcNow;
        Status = OrderStatus.Submitted;
        _orderItems = new();
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
        foreach (OrderItem orderItem in _orderItems)
        {
            TotalAmount += orderItem.TotalPrice;
        }

        AddOrderPurchasedDomainEvent();
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

    public bool IsCompleted()
    {
        return Status == OrderStatus.Completed;
    }

    private void AddOrderPurchasedDomainEvent()
    {
        OrderPurchasedDomainEvent orderPurchasedDomainEvent = new(SupplierId, PurchaseDate, Status, OrderItems);

        this.AddDomainEvent(orderPurchasedDomainEvent);
    }

    private void AddOrderStatusUpdatedDomainEvent()
    {
        OrderStatusUpdatedDomainEvent orderStatusUpdatedDomainEvent = new(Id, Status);

        this.AddDomainEvent(orderStatusUpdatedDomainEvent);
    }
}
