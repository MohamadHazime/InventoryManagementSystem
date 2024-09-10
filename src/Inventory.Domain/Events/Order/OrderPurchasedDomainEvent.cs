﻿using Inventory.Domain.AggregatesModel.OrderAggregate;
using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Events;

public class OrderPurchasedDomainEvent : DomainEvent
{
    public int SupplierId { get; private set; }
    public DateTime PurchaseDate { get; private set; }
    public OrderStatus Status { get; private set; }

    public OrderPurchasedDomainEvent(int supplierId, DateTime purchaseDate, OrderStatus status)
    {
        SupplierId = supplierId;
        PurchaseDate = purchaseDate;
        Status = status;
    }
}
