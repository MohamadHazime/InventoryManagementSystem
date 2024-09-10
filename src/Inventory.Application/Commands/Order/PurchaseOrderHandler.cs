using Inventory.Domain.AggregatesModel.ItemAggregate;
using Inventory.Domain.AggregatesModel.OrderAggregate;
using Inventory.Domain.AggregatesModel.SupplierAggregate;
using Inventory.Domain.Exceptions;
using MediatR;

namespace Inventory.Application.Commands;

public class PurchaseOrderHandler : IRequestHandler<PurchaseOrderCommand, bool>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IItemRepository _itemRepository;
    private readonly ISupplierRepository _supplierRepository;

    public PurchaseOrderHandler(
        IOrderRepository orderRepository,
        IItemRepository itemRepository,
        ISupplierRepository supplierRepository)
    {
        _orderRepository = orderRepository;
        _itemRepository = itemRepository;
        _supplierRepository = supplierRepository;
    }

    public async Task<bool> Handle(PurchaseOrderCommand request, CancellationToken cancellationToken)
    {
        Supplier supplier = await _supplierRepository.GetAsync(request.SupplierId);

        if (supplier == null)
        {
            throw new SupplierNotExistsDomainException(request.SupplierId);
        }

        Order order = new(request.SupplierId);

        foreach (var orderItem in request.Items)
        {
            Item item = await _itemRepository.GetAsync(orderItem.Id);

            if (item == null)
            {
                throw new ItemNotExistsDomainException(request.SupplierId);
            }

            order.AddOrderItem(item.Id, orderItem.Quantity, item.Price);
        }

        order.CalculateTotalAmount();

        _orderRepository.Add(order);

        await _orderRepository.UnitOfWork.SaveEntitiesAsync();

        return true;
    }
}
