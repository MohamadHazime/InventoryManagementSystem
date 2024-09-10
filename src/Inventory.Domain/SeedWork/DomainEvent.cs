using MediatR;

namespace Inventory.Domain.SeedWork;

public abstract class DomainEvent : INotification
{
    public DateTime CreatedAt { get; set; }

    public DomainEvent()
    {
        CreatedAt = DateTime.UtcNow;
    }
}
