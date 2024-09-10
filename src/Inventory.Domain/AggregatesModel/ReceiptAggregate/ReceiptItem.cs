﻿using Inventory.Domain.AggregatesModel.ItemAggregate;
using Inventory.Domain.Exceptions;
using Inventory.Domain.SeedWork;

namespace Inventory.Domain.AggregatesModel.ReceiptAggregate;

public class ReceiptItem : Entity
{
    public int ItemId { get; private set; }
    public Item Item { get; private set; }
    public int QuantityReceived { get; private set; }

    public ReceiptItem(int itemId, int quantityReceived)
    {
        if (quantityReceived <= 0)
        {
            throw new InvalidReceiptItemQuantityException();
        }

        ItemId = itemId;
        QuantityReceived = quantityReceived;
    }
}
