using Inventory.Domain.SeedWork;

namespace Inventory.Domain.AggregatesModel.SupplierAggregate;

public interface ISupplierRepository : IEntityRepository<Supplier>, IRepository<Supplier>
{
    Task<Supplier> GetByEmailAsync(string supplierEmail);
    Task<Supplier> GetByPhoneNumberAsync(string supplierPhoneNumber);
}
