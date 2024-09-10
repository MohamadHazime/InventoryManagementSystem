using FluentValidation;
using Inventory.Application.Commands;
using Inventory.Domain.AggregatesModel.SupplierAggregate;

namespace Inventory.Application.Validators;

public class UpdateSupplierValidator : AbstractValidator<UpdateSupplierCommand>
{
    private readonly ISupplierRepository _supplierRepository;

    public UpdateSupplierValidator(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;

        RuleFor(request => request.FirstName).NotEmpty();
        RuleFor(request => request.LastName).NotEmpty();
        RuleFor(request => request.PhoneNumber)
            .NotEmpty().WithMessage("Phone Number is required.")
            .MustAsync(async (command, phoneNumber, cancellation) =>
            {
                Supplier supplier = await _supplierRepository.GetByPhoneNumberAsync(phoneNumber);

                return supplier == null || supplier.Id == command.Id;
            }).WithMessage("Phone Number already exists.");
    }
}
