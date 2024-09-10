using FluentValidation;
using Inventory.Application.Commands;

namespace Inventory.Application.Validators;

public class DeleteSupplierValidator : AbstractValidator<DeleteSupplierCommand>
{
    public DeleteSupplierValidator()
    {
        RuleFor(request => request.Id).NotEmpty();
    }
}
