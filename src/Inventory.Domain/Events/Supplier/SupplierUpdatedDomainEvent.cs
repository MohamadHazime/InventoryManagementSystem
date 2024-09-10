using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Events;

public class SupplierUpdatedDomainEvent : DomainEvent
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string PhoneNumber { get; private set; }

    public SupplierUpdatedDomainEvent(string firstName, string lastName, string phoneNumber) : base()
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }
}
