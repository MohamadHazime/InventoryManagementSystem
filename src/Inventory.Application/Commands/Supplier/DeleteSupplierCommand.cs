using MediatR;

namespace Inventory.Application.Commands;

public class DeleteSupplierCommand : IRequest<bool>
{
    public int Id { get; private set; }

    public DeleteSupplierCommand(int id)
    {
        Id = id;
    }
}
