using Inventory.Domain.SeedWork;

namespace Inventory.Domain.AggregatesModel.ReceiptAggregate;

public interface IReceiptRepository : IEntityRepository<Receipt>, IRepository<Receipt>
{
}
