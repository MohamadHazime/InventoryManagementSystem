using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Exceptions;

public class ConcurrencyConflictException : DomainException
{
    public ConcurrencyConflictException(string entityName, int entityId) : base($"The ${entityName}: {entityId} was modified by another user.")
    { }
}
