using Inventory.Domain.AggregatesModel.OrderAggregate;
using Inventory.Domain.Exceptions;
using MediatR;

namespace Inventory.Application.Commands;

public class UpdateOrderStatusHandler : IRequestHandler<UpdateOrderStatusCommand, bool>
{
    private readonly IOrderRepository _orderRepository;

    public UpdateOrderStatusHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<bool> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
    {
        Order order = await _orderRepository.GetAsync(request.OrderId);

        if (order == null)
        {
            throw new OrderNotExistsException(request.OrderId);
        }

        if (order.IsFinalStatus())
        {
            throw new OrderStatusChangeNotAllowedException(request.OrderId);
        }

        order.UpdateOrderStatus(request.IsCompleted);

        _orderRepository.Update(order);

        await _orderRepository.UnitOfWork.SaveEntitiesAsync();

        return true;
    }
}
