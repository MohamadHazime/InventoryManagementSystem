using MediatR;

namespace Inventory.Domain.Notifications;

public class ReceiptCreatedNotification : INotification
{
    public int ReceiptId { get; private set; }

    public ReceiptCreatedNotification(int receiptId)
    {
        ReceiptId = receiptId;
    }
}
