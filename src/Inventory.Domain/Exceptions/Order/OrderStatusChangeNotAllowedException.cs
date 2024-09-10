using Inventory.Domain.AggregatesModel.OrderAggregate;
using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Exceptions;

public class OrderStatusChangeNotAllowedException : DomainException
{
    public OrderStatusChangeNotAllowedException(int orderId) 
        : base($"Cannot update status for order: {orderId}")
    {
        
    }
}
