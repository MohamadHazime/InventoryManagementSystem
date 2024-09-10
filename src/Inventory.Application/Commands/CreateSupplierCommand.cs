﻿using Inventory.Application.DTOs;
using MediatR;

namespace Inventory.Application.Commands;

public class CreateSupplierCommand : IRequest<SupplierDto>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }

    public CreateSupplierCommand(string firstName, string lastName, string email, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}
