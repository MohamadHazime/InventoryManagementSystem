using Inventory.Application.DTOs;
using MediatR;

namespace Inventory.Application.Queries;

public class GetSupplierQuery : IRequest<SupplierDto>
{
    public int SupplierId { get; private set; }

    public GetSupplierQuery(int supplierId)
    {
        SupplierId = supplierId;
    }
}
