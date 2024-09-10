using Inventory.Application.Commands;
using Inventory.Application.DTOs;
using Inventory.Application.Queries;
using Inventory.Domain.AggregatesModel.ReceiptAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReceiptController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReceiptController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ResponseBase<ReceiptDto>> Get(int id)
    {
        var result = await _mediator.Send(new GetReceiptQuery(id));
        return new ResponseBase<ReceiptDto>(result, true);
    }

    [HttpPost("Create")]
    public async Task<ResponseBase<bool>> Create(CreateReceiptCommand command)
    {
        var result = await _mediator.Send(command);
        return new ResponseBase<bool>(result, true);
    }
}
