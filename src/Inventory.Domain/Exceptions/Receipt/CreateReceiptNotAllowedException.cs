using Inventory.Domain.SeedWork;

namespace Inventory.Domain.Exceptions;

public class CreateReceiptNotAllowedException : DomainException
{
    public CreateReceiptNotAllowedException() : base("Create Receipt is allowed only for completed orders.")
    { }
}
