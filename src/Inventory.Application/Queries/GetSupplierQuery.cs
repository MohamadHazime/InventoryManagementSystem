using Inventory.Application.DTOs;
using MediatR;

namespace Inventory.Application.Queries;

public class GetSupplierQuery : IRequest<SupplierDto>
{
    public int Id { get; private set; }

    public GetSupplierQuery(int id)
    {
        Id = id;
    }
}
