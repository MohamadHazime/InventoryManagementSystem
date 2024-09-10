using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Exceptions;

public class InvalidReceiptItemQuantityException : DomainException
{
    public InvalidReceiptItemQuantityException() : base("Receipt item quantity can't be less than or equal to 0.")
    { }
}
