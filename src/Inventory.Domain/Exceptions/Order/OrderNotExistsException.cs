using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Exceptions;

public class OrderNotExistsException : DomainException
{
    public OrderNotExistsException(int id) : base($"Order with Id {id} not exists.")
    { }
}
