using Inventory.Domain.AggregatesModel.OrderAggregate;
using Inventory.Domain.SeedWork;

namespace Inventory.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly InventoryDbContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public OrderRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public Order Add(Order order)
    {
        return _context.Orders.Add(order).Entity;
    }

    public async Task<Order> GetAsync(int orderId)
    {
        Order order = await _context.Orders.FindAsync(orderId);

        if (order != null)
        {
            await _context.Entry(order).Collection(o => o.OrderItems).LoadAsync();
        }

        return order;
    }

    public void Update(Order order)
    {
        _context.Orders.Update(order);
    }

    public async Task<bool> DeleteAsync(int orderId)
    {
        Order order = await GetAsync(orderId);

        if (order != null)
        {
            _context.Orders.Remove(order);

            return true;
        }

        return false;
    }
}
