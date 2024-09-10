using Inventory.Domain.Events;
using Inventory.Domain.SeedWork;

namespace Inventory.Domain.AggregatesModel.SupplierAggregate;

public class Supplier : Entity, IAggregateRoot
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }

    public Supplier(string firstName, string lastName, string email, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;

        AddSupplierCreatedDomainEvent();
    }

    public void UpdateSupplier(string firstName, string lastName, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;

        AddSupplierUpdatedDomainEvent();
    }

    private void AddSupplierCreatedDomainEvent()
    {
        SupplierCreatedDomainEvent supplierCreatedDomainEvent = new(FirstName, LastName, Email, PhoneNumber);

        AddDomainEvent(supplierCreatedDomainEvent);
    }

    private void AddSupplierUpdatedDomainEvent()
    {
        SupplierUpdatedDomainEvent supplierUpdatedDomainEvent = new(Id, FirstName, LastName, PhoneNumber);

        AddDomainEvent(supplierUpdatedDomainEvent);
    }
}
