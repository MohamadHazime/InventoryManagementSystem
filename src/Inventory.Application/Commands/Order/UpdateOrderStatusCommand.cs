using MediatR;

namespace Inventory.Application.Commands;

public class UpdateOrderStatusCommand : IRequest<bool>
{
    public int OrderId { get; private set; }
    public bool IsCompleted { get; private set; }

    public UpdateOrderStatusCommand(int orderId, bool isCompleted)
    {
        OrderId = orderId;
        IsCompleted = isCompleted;
    }
}
