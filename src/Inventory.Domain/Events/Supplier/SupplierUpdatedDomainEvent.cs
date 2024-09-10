using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Events;

public class SupplierUpdatedDomainEvent : DomainEvent
{
    public int SupplierId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string PhoneNumber { get; private set; }

    public SupplierUpdatedDomainEvent(int supplierId, string firstName, string lastName, string phoneNumber) : base()
    {
        SupplierId = supplierId;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }
}
