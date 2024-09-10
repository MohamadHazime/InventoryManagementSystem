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

        AddSupplierCreatedDomainEvent(firstName, lastName, email, phoneNumber);
    }

    public void UpdateSupplier(string firstName, string lastName, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;

        AddSupplierUpdatedDomainEvent(firstName, lastName, phoneNumber);
    }

    private void AddSupplierCreatedDomainEvent(string firstName, string lastName, string email, string phoneNumber)
    {
        SupplierCreatedDomainEvent supplierCreatedDomainEvent = new(firstName, lastName, email, phoneNumber);

        AddDomainEvent(supplierCreatedDomainEvent);
    }

    private void AddSupplierUpdatedDomainEvent(string firstName, string lastName, string phoneNumber)
    {
        SupplierUpdatedDomainEvent supplierUpdatedDomainEvent = new(firstName, lastName, phoneNumber);

        AddDomainEvent(supplierUpdatedDomainEvent);
    }
}
