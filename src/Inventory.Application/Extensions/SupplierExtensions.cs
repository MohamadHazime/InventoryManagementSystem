using Inventory.Application.DTOs;
using Inventory.Domain.AggregatesModel.SupplierAggregate;

namespace Inventory.Application.Extensions;

public static class SupplierExtensions
{
    public static SupplierDto ToDto(this Supplier supplier)
    {
        return new SupplierDto(supplier.Id, supplier.FirstName, supplier.LastName, supplier.Email, supplier.PhoneNumber);
    }
}
