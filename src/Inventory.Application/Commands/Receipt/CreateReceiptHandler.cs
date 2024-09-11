using Inventory.Application.DTOs;
using Inventory.Application.Extensions;
using Inventory.Domain.AggregatesModel.ItemAggregate;
using Inventory.Domain.AggregatesModel.OrderAggregate;
using Inventory.Domain.AggregatesModel.ReceiptAggregate;
using Inventory.Domain.Exceptions;
using Inventory.Domain.Notifications;
using MediatR;

namespace Inventory.Application.Commands;

public class CreateReceiptHandler : IRequestHandler<CreateReceiptCommand, ReceiptDto>
{
    private readonly IReceiptRepository _receiptRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IItemRepository _itemRepository;
    private readonly IMediator _mediator;

    public CreateReceiptHandler(
        IReceiptRepository receiptRepository,
        IOrderRepository orderRepository,
        IItemRepository itemRepository,
        IMediator mediator)
    {
        _receiptRepository = receiptRepository;
        _orderRepository = orderRepository;
        _itemRepository = itemRepository;
        _mediator = mediator;
    }

    public async Task<ReceiptDto> Handle(CreateReceiptCommand request, CancellationToken cancellationToken)
    {
        Order order = await _orderRepository.GetAsync(request.OrderId);

        if (order == null)
        {
            throw new OrderNotExistsException(request.OrderId);
        }

        if (!order.IsCompleted())
        {
            throw new CreateReceiptNotAllowedException();
        }

        Receipt receipt = await _receiptRepository.GetByOrderIdAsync(request.OrderId);

        if (receipt != null)
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

        receipt.ConfirmReceipt();

        Receipt addedReceipt = _receiptRepository.Add(receipt);

        await _mediator.Publish(new ReceiptCreatedNotification(addedReceipt.Id));

        await _receiptRepository.UnitOfWork.SaveEntitiesAsync();

        return receipt.ToDto(order);
    }
}
