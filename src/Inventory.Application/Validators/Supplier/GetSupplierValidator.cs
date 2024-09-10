using FluentValidation;
using Inventory.Application.Queries;

namespace Inventory.Application.Validators;

public class GetReceiptValidator : AbstractValidator<GetReceiptQuery>
{
    public GetReceiptValidator()
    {
        RuleFor(request => request.ReceiptId).NotEmpty();
    }
}
