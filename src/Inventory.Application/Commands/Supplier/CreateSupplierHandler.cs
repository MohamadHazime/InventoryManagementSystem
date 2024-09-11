using Inventory.Application.DTOs;
using Inventory.Application.Extensions;
using Inventory.Domain.AggregatesModel.SupplierAggregate;
using MediatR;

namespace Inventory.Application.Commands;

public class CreateSupplierHandler : IRequestHandler<CreateSupplierCommand, SupplierDto>
{
    private readonly ISupplierRepository _supplierRepository;

    public CreateSupplierHandler(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<SupplierDto> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
    {
        Supplier supplier = new(
            request.FirstName,
            request.LastName,
            request.Email,
            request.PhoneNumber);

        Supplier savedSupplier = _supplierRepository.Add(supplier);

        await _supplierRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return savedSupplier.ToDto();
    }
}
