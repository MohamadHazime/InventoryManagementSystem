using Inventory.Application.DTOs;
using Inventory.Domain.AggregatesModel.OrderAggregate;
using Inventory.Domain.AggregatesModel.ReceiptAggregate;

namespace Inventory.Application.Extensions;

public static class ReceiptExtensions
{
    public static ReceiptDto ToDto(this Receipt receipt, Order order)
    {
        List<ReceiptItemDto> items = new();

        foreach (ReceiptItem receiptItem in receipt.ReceiptItems)
        {
            OrderItem orderItem = order.OrderItems.FirstOrDefault(oi => oi.ItemId == receiptItem.ItemId);

            if (orderItem != null)
            {
                items.Add(new ReceiptItemDto(receiptItem.ItemId, orderItem.Quantity, receiptItem.QuantityReceived));
            }
        }

        return new ReceiptDto(receipt.Id, receipt.CreatedDate, items);
    }
}
