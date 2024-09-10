using Inventory.Application.Commands;
using Inventory.Application.DTOs;
using Inventory.Domain.AggregatesModel.OrderAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IOrderRepository _orderRepo;

    public OrderController(IMediator mediator, IOrderRepository orderRepo)
    {
        _mediator = mediator;
        _orderRepo = orderRepo;
    }

    [HttpPost("PurchaseOrder")]
    public async Task<ResponseBase<bool>> PurchaseOrder(PurchaseOrderCommand command)
    {
        var result = await _mediator.Send(command);
        return new ResponseBase<bool>(result, true);
    }
}
