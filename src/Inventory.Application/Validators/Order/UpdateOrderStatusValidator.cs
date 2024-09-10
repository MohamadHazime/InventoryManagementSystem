using FluentValidation;
using Inventory.Application.Commands;

namespace Inventory.Application.Validators;

public class UpdateOrderStatusValidator : AbstractValidator<UpdateOrderStatusCommand>
{
    public UpdateOrderStatusValidator()
    {
        RuleFor(c => c.OrderId).NotEmpty();
    }
}
