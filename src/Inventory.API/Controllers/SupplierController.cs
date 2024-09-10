using Inventory.Application.Commands;
using Inventory.Application.DTOs;
using Inventory.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupplierController : ControllerBase
{
    private readonly IMediator _mediator;

    public SupplierController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("")]
    public async Task<ResponseBase<SupplierDto>> AddSupplier(CreateSupplierCommand command)
    {
        SupplierDto supplier = await _mediator.Send(command);

        return new ResponseBase<SupplierDto>(supplier, true);
    }

    [HttpGet("{id}")]
    public async Task<ResponseBase<SupplierDto>> GetSupplierById(int id)
    {
        SupplierDto supplier = await _mediator.Send(new GetSupplierQuery(id));

        return new ResponseBase<SupplierDto>(supplier, true);
    }


    [HttpPut("Update")]
    public async Task<ResponseBase<SupplierDto>> UpdateSupplier(UpdateSupplierCommand command)
    {
        SupplierDto supplier = await _mediator.Send(command);

        return new ResponseBase<SupplierDto>(supplier, true);
    }

    [HttpDelete("{id}")]
    public async Task<ResponseBase<bool>> DeleteSupplier(int id)
    {
        bool result = await _mediator.Send(new DeleteSupplierCommand(id));

        return new ResponseBase<bool>(result, true);
    }
}
