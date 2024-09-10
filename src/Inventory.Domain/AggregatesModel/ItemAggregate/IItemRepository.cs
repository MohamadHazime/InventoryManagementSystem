using Inventory.Domain.SeedWork;

namespace Inventory.Domain.AggregatesModel.ItemAggregate;

public interface IItemRepository : IEntityRepository<Item>, IRepository<Item>
{
}
