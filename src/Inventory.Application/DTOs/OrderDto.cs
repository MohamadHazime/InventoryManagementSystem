namespace Inventory.Application.DTOs;

public record OrderDto(int Id, IEnumerable<OrderItemDto> Items, double TotalAmount);
