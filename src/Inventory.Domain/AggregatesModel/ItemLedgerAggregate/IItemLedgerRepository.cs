using Inventory.Domain.SeedWork;

namespace Inventory.Domain.AggregatesModel.ItemLedgerAggregate;

public interface IItemLedgerRepository : IEntityRepository<ItemLedger>, IRepository<ItemLedger>
{
}
