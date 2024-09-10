using Inventory.Application.DTOs;
using Inventory.Domain.AggregatesModel.ReceiptAggregate;
using MediatR;

namespace Inventory.Application.Queries;

public class GetReceiptQuery : IRequest<ReceiptDto>
{
    public int ReceiptId { get; private set; }

    public GetReceiptQuery(int receiptId)
    {
        ReceiptId = receiptId;
    }
}
