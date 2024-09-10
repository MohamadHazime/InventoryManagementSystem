using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Exceptions;

public class ItemNotExistsInOrderException : DomainException
{
    public ItemNotExistsInOrderException(int id, int orderId) : base($"Item with Id {id} not exists in order: {orderId}.")
    { }
}
