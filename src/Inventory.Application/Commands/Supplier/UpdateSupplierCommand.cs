using Inventory.Application.DTOs;
using MediatR;

namespace Inventory.Application.Commands;

public class UpdateSupplierCommand : IRequest<SupplierDto>
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string PhoneNumber { get; private set; }

    public UpdateSupplierCommand(int id, string firstName, string lastName, string phoneNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }
}
