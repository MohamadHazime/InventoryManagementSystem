using Inventory.Domain.AggregatesModel.ItemAggregate;
using Inventory.Domain.AggregatesModel.OrderAggregate;
using Inventory.Domain.AggregatesModel.ReceiptAggregate;
using Inventory.Domain.Exceptions;
using MediatR;

namespace Inventory.Application.Commands;

public class CreateReceiptHandler : IRequestHandler<CreateReceiptCommand, bool>
{
    private readonly IReceiptRepository _receiptRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IItemRepository _itemRepository;

    public CreateReceiptHandler(
        IReceiptRepository receiptRepository,
        IOrderRepository orderRepository,
        IItemRepository itemRepository)
    {
        _receiptRepository = receiptRepository;
        _orderRepository = orderRepository;
        _itemRepository = itemRepository;
    }

    public async Task<bool> Handle(CreateReceiptCommand request, CancellationToken cancellationToken)
    {
        Order order = await _orderRepository.GetAsync(request.OrderId);

        if (order == null)
        {
            throw new OrderNotExistsException(request.OrderId);
        }

        if(!order.IsCompleted())
        {
            throw new CreateReceiptNotAllowedException();
        }

        Receipt receipt = await _receiptRepository.GetByOrderIdAsync(request.OrderId);

        if(receipt != null)
        {
            throw new ReceiptForOrderExistsException(request.OrderId);
        }

        receipt = new(request.OrderId);

        foreach (var reciptItem in request.Items)
        {
            Item item = await _itemRepository.GetAsync(reciptItem.Id);

            if (item == null)
            {
                throw new ItemNotExistsDomainException(reciptItem.Id);
            }

            OrderItem orderItem = order.OrderItems.FirstOrDefault(oi => oi.ItemId == reciptItem.Id);

            if (orderItem == null)
            {
                throw new ItemNotExistsInOrderException(item.Id, request.OrderId);
            }

            receipt.AddReceiptItem(item.Id, reciptItem.QuantityReceived, orderItem.Quantity);
        }

        _receiptRepository.Add(receipt);

        await _receiptRepository.UnitOfWork.SaveEntitiesAsync();

        return true;
    }
}
