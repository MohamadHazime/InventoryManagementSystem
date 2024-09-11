using Inventory.Application.Commands;
using Inventory.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("PurchaseOrder")]
    public async Task<ResponseBase<OrderDto>> PurchaseOrder(PurchaseOrderCommand command)
    {
        OrderDto order = await _mediator.Send(command);
        return new ResponseBase<OrderDto>(order, true);
    }

    [HttpPost("UpdateStatus")]
    public async Task<ResponseBase<bool>> UpdateStatus(UpdateOrderStatusCommand command)
    {
        var result = await _mediator.Send(command);
        return new ResponseBase<bool>(result, true);
    }
}
