using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Exceptions;

public class ReceiptForOrderExistsException : DomainException
{
    public ReceiptForOrderExistsException(int orderId) : base($"Receipt for order {orderId} already exists.")
    { }
}
