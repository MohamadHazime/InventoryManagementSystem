using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Exceptions;

public class InvalidOrderItemQuantityException : DomainException
{
    public InvalidOrderItemQuantityException() : base("Order item quantity can't be less than or equal to 0.")
    { }
}
