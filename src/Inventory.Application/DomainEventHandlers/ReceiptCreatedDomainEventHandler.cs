using Inventory.Domain.AggregatesModel.ItemAggregate;
using Inventory.Domain.AggregatesModel.ReceiptAggregate;
using Inventory.Domain.Events.Receipt;
using MediatR;

namespace Inventory.Application.DomainEventHandlers;

public class ReceiptCreatedDomainEventHandler : INotificationHandler<ReceiptCreatedDomainEvent>
{
    private readonly IReceiptRepository _receiptRepository;
    private readonly IItemRepository _itemsRepository;

    public ReceiptCreatedDomainEventHandler(IReceiptRepository receiptRepository, IItemRepository itemsRepository)
    {
        _receiptRepository = receiptRepository;
        _itemsRepository = itemsRepository;
    }

    public async Task Handle(ReceiptCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        foreach(ReceiptItem receiptItem in notification.ReceiptItems)
        {
            Item item = await _itemsRepository.GetAsync(receiptItem.ItemId);

            item.UpdateQuantity(receiptItem.QuantityReceived);

            _itemsRepository.Update(item);
        }

        await _itemsRepository.UnitOfWork.SaveEntitiesAsync();
    }
}
