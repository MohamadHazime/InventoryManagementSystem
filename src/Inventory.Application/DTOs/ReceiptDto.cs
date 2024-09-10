namespace Inventory.Application.DTOs;

public record ReceiptDto(int Id, DateTime CreatedDate, IEnumerable<ReceiptItemDto> ReceiptItems);
