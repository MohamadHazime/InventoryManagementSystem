using Inventory.Domain.AggregatesModel.SupplierAggregate;
using Inventory.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly InventoryDbContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public SupplierRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public Supplier Add(Supplier supplier)
    {
        return _context.Suppliers.Add(supplier).Entity;
    }

    public async Task<Supplier> GetAsync(int supplierId)
    {
        return await _context.Suppliers.FindAsync(supplierId);
    }

    public void Update(Supplier supplier)
    {
        _context.Suppliers.Update(supplier);
    }

    public async Task<bool> DeleteAsync(int supplierId)
    {
        Supplier supplier = await GetAsync(supplierId);

        if (supplier != null)
        {
            _context.Suppliers.Remove(supplier);

            return true;
        }

        return false;
    }

    public async Task<Supplier> GetByEmailAsync(string supplierEmail)
    {
        return await _context.Suppliers.FirstOrDefaultAsync(s => s.Email.ToLower() == supplierEmail.ToLower());
    }

    public async Task<Supplier> GetByPhoneNumberAsync(string supplierPhoneNumber)
    {
        return await _context.Suppliers.FirstOrDefaultAsync(s => s.PhoneNumber.ToLower() == supplierPhoneNumber.ToLower());
    }
}
