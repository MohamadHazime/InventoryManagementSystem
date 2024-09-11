using Inventory.Domain.AggregatesModel.SupplierAggregate;
using MediatR;

namespace Inventory.Application.Commands;

public class DeleteSupplierHandler : IRequestHandler<DeleteSupplierCommand, bool>
{
    private readonly ISupplierRepository _supplierRepository;

    public DeleteSupplierHandler(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<bool> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
    {
        bool result = await _supplierRepository.DeleteAsync(request.Id);
        await _supplierRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return result;
    }
}
