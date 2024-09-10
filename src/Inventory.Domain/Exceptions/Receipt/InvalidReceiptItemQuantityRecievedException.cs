using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Exceptions;

public class InvalidReceiptItemQuantityReceivedException : DomainException
{
    public InvalidReceiptItemQuantityReceivedException()
        : base("Receipt item quantity can't be greater than order item quantity.")
    { }
}
