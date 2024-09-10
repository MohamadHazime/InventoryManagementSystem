namespace Inventory.Application.DTOs;

public record ReceiptItemDto(int ItemId, int Quantity, int QuantityReceived)
{
    public bool Received => QuantityReceived == Quantity;
}
