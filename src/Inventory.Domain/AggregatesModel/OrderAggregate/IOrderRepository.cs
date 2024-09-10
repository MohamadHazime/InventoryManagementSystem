using Inventory.Domain.SeedWork;

namespace Inventory.Domain.AggregatesModel.OrderAggregate;

public interface IOrderRepository : IEntityRepository<Order>, IRepository<Order>
{
}
