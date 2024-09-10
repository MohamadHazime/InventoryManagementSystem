using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Exceptions;

public class SupplierNotExistsDomainException : DomainException
{
    public SupplierNotExistsDomainException(int id) : base($"Supplier with Id {id} not exists.")
    { }
}
