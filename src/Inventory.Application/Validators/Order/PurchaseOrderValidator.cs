using FluentValidation;
using Inventory.Application.Commands;
using Inventory.Application.DTOs;

namespace Inventory.Application.Validators;

public class PurchaseOrderValidator : AbstractValidator<PurchaseOrderCommand>
{
    public PurchaseOrderValidator()
    {
        RuleFor(o => o.SupplierId).NotEmpty();
        RuleFor(o => o.Items).NotEmpty();
        RuleForEach(o => o.Items).SetValidator(new ItemDtoValidator());
    }
}

public class ItemDtoValidator : AbstractValidator<ItemDto>
{
    public ItemDtoValidator()
    {
        RuleFor(item => item.Id).NotEmpty();
        RuleFor(item => item.Quantity).GreaterThan(0);
    }
}
