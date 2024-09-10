using Inventory.Domain.SeedWork;

namespace Inventory.Domain.AggregatesModel.SupplierAggregate;

public interface ISupplierRepository : IRepository<Supplier>
{
    Supplier Add(Supplier supplier);
    Task<Supplier> GetAsync(int supplierId);
    void Update(Supplier supplier);
    Task<bool> DeleteAsync(int supplierId);
    Task<Supplier> GetByEmailAsync(string supplierEmail);
    Task<Supplier> GetByPhoneNumberAsync(string supplierPhoneNumber);
}
