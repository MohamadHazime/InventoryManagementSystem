using FluentValidation;
using Inventory.Application.Commands;
using Inventory.Application.DTOs;

namespace Inventory.Application.Validators;

public class CreateReceiptValidator : AbstractValidator<CreateReceiptCommand>
{
    public CreateReceiptValidator()
    {
        RuleFor(o => o.OrderId).NotEmpty();
        RuleFor(o => o.Items).NotEmpty();
        RuleForEach(o => o.Items).SetValidator(new CreateReceiptItemDtoValidator());
    }
}

public class CreateReceiptItemDtoValidator : AbstractValidator<CreateReceiptItemDto>
{
    public CreateReceiptItemDtoValidator()
    {
        RuleFor(item => item.Id).NotEmpty();
        RuleFor(item => item.QuantityReceived).GreaterThan(0);
    }
}
