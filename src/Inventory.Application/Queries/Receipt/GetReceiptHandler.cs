using Inventory.Application.DTOs;
using Inventory.Application.Extensions;
using Inventory.Domain.AggregatesModel.OrderAggregate;
using Inventory.Domain.AggregatesModel.ReceiptAggregate;
using MediatR;

namespace Inventory.Application.Queries;

public class GetReceiptHandler : IRequestHandler<GetReceiptQuery, ReceiptDto>
{
    private readonly IReceiptRepository _receiptRepository;
    private readonly IOrderRepository _orderRepository;

    public GetReceiptHandler(IReceiptRepository receiptRepository, IOrderRepository orderRepository)
    {
        _receiptRepository = receiptRepository;
        _orderRepository = orderRepository;
    }

    public async Task<ReceiptDto> Handle(GetReceiptQuery request, CancellationToken cancellationToken)
    {
        Receipt receipt = await _receiptRepository.GetAsync(request.ReceiptId);

        if (receipt == null) return null;

        Order order = await _orderRepository.GetAsync(receipt.OrderId);

        if (order == null) return null;

        return receipt.ToDto(order);
    }
}
