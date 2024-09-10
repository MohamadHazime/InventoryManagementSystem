using FluentValidation;
using Inventory.Application.Commands;
using Inventory.Domain.AggregatesModel.SupplierAggregate;

namespace Inventory.Application.Validators;

public class CreateSupplierValidator : AbstractValidator<CreateSupplierCommand>
{
    private readonly ISupplierRepository _supplierRepository;

    public CreateSupplierValidator(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;

        RuleFor(request => request.FirstName).NotEmpty();
        RuleFor(request => request.LastName).NotEmpty();
        RuleFor(request => request.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.")
            .MustAsync(async (email, cancellation) =>
            {
                Supplier supplier = await _supplierRepository.GetByEmailAsync(email);

                return supplier == null;
            }).WithMessage("Email already exists.");
        RuleFor(request => request.PhoneNumber)
            .NotEmpty().WithMessage("Phone Number is required.")
            .MustAsync(async (phoneNumber, cancellation) =>
            {
                Supplier supplier = await _supplierRepository.GetByPhoneNumberAsync(phoneNumber);

                return supplier == null;
            }).WithMessage("Phone Number already exists.");
    }
}
