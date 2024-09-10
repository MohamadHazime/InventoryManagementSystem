using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Exceptions;

public class ItemNotExistsDomainException : DomainException
{
    public ItemNotExistsDomainException(int id) : base($"Item with Id {id} not exists.")
    { }
}
