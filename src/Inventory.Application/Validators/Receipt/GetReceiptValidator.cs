using FluentValidation;
using Inventory.Application.Queries;

namespace Inventory.Application.Validators;

public class GetSupplierValidator : AbstractValidator<GetSupplierQuery>
{
    public GetSupplierValidator()
    {
        RuleFor(request => request.SupplierId).NotEmpty();
    }
}
