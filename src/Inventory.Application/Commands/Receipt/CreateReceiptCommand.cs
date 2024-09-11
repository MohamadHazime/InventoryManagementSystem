using Inventory.Application.DTOs;
using MediatR;

namespace Inventory.Application.Commands;

public class CreateReceiptCommand : IRequest<ReceiptDto>
{
    public int OrderId { get; private set; }
    public IEnumerable<CreateReceiptItemDto> Items { get; private set; }

    public CreateReceiptCommand(int orderId, IEnumerable<CreateReceiptItemDto> items)
    {
        OrderId = orderId;
        Items = items;
    }
}
