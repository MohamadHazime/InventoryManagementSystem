using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Events;

public class SupplierCreatedDomainEvent : DomainEvent
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }

    public SupplierCreatedDomainEvent(string firstName, string lastName, string email, string phoneNumber) : base()
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}
