using Inventory.Application.DTOs;
using Inventory.Application.Extensions;
using Inventory.Domain.AggregatesModel.SupplierAggregate;
using Inventory.Domain.Exceptions;
using MediatR;

namespace Inventory.Application.Queries;

public class GetSupplierHandler : IRequestHandler<GetSupplierQuery, SupplierDto>
{
    private readonly ISupplierRepository _supplierRepository;

    public GetSupplierHandler(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<SupplierDto> Handle(GetSupplierQuery request, CancellationToken cancellationToken)
    {
        Supplier supplier = await _supplierRepository.GetAsync(request.SupplierId);

        if(supplier == null)
        {
            throw new SupplierNotExistsDomainException(request.SupplierId);
        }

        return supplier.ToDto();
    }
}
