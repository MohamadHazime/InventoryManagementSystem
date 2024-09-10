using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Exceptions;

public class InvalidOrderItemQuantityException : DomainException
{
    public InvalidOrderItemQuantityException() : base("Order item quantity can't be greater or equal to 0.")
    { }
}
