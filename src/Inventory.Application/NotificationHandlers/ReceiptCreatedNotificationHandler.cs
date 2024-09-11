using Inventory.Domain.AggregatesModel.ItemLedgerAggregate;
using Inventory.Domain.AggregatesModel.ReceiptAggregate;
using Inventory.Domain.Notifications;
using MediatR;

namespace Inventory.Application.NotificationHandlers;

public class ReceiptCreatedNotificationHandler : INotificationHandler<ReceiptCreatedNotification>
{
    private readonly IReceiptRepository _receiptRepository;
    private readonly IItemLedgerRepository _itemLedgerRepository;

    public ReceiptCreatedNotificationHandler(IReceiptRepository receiptRepository, IItemLedgerRepository itemLedgerRepository)
    {
        _receiptRepository = receiptRepository;
        _itemLedgerRepository = itemLedgerRepository;
    }

    public async Task Handle(ReceiptCreatedNotification notification, CancellationToken cancellationToken)
    {
        Receipt receipt = await _receiptRepository.GetAsync(notification.ReceiptId);

        foreach(ReceiptItem receiptItem in receipt.ReceiptItems)
        {
            ItemLedger itemLedger = new(receiptItem.ItemId, receiptItem.QuantityReceived, ItemLedgerType.Purchase, receipt.Id);

            _itemLedgerRepository.Add(itemLedger);
        }

        await _itemLedgerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
