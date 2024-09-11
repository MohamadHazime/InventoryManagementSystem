using Inventory.Application.DTOs;
using Inventory.Domain.AggregatesModel.OrderAggregate;

namespace Inventory.Application.Extensions;

public static class OrderExtensions
{
    public static OrderDto ToDto(this Order order)
    {
        List<OrderItemDto> items = new();

        foreach(OrderItem orderItem in order.OrderItems)
        {
            items.Add(new OrderItemDto(orderItem.Id, orderItem.Quantity, orderItem.UnitPrice));
        }

        return new OrderDto(order.Id, items, order.TotalAmount);
    }
}
