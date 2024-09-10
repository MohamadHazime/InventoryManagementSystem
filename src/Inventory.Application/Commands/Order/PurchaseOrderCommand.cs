using Inventory.Application.DTOs;
using MediatR;

namespace Inventory.Application.Commands;

public class PurchaseOrderCommand : IRequest<bool>
{
    public int SupplierId { get; private set; }
    public IEnumerable<ItemDto> Items { get; private set; }

    public PurchaseOrderCommand(int supplierId, IEnumerable<ItemDto> items)
    {
        SupplierId = supplierId;
        Items = items;
    }
}
