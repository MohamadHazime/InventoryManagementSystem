using Inventory.Domain.SeedWork;

namespace Inventory.Domain.AggregatesModel.ItemAggregate;

public interface IItemRepository : IRepository<Item>
{
    Task<Item> GetAsync(int itemId);
    void Update(Item item);
}
