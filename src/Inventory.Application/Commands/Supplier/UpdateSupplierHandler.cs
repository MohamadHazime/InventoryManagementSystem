using Inventory.Application.DTOs;
using Inventory.Application.Extensions;
using Inventory.Domain.AggregatesModel.OrderAggregate;
using Inventory.Domain.AggregatesModel.SupplierAggregate;
using Inventory.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Application.Commands;

public class UpdateSupplierHandler : IRequestHandler<UpdateSupplierCommand, SupplierDto>
{
    private readonly ISupplierRepository _supplierRepository;

    public UpdateSupplierHandler(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<SupplierDto> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
    {
        Supplier supplier = await _supplierRepository.GetAsync(request.Id);

        if (supplier == null) throw new SupplierNotExistsDomainException(request.Id);

        supplier.UpdateSupplier(request.FirstName, request.LastName, request.PhoneNumber);

        try
        {
            _supplierRepository.Update(supplier);

            await _supplierRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            foreach (var entry in ex.Entries)
            {
                var databaseValues = await entry.GetDatabaseValuesAsync();
                var clientValues = entry.CurrentValues;

                throw new ConcurrencyConflictException(nameof(Supplier), supplier.Id);
            }
        }

        return supplier.ToDto();
    }
}
