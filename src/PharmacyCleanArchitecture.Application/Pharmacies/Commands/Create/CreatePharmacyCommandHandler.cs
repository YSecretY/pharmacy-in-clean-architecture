using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;
using PharmacyCleanArchitecture.Domain.Common.ValueObjects.Address;
using PharmacyCleanArchitecture.Domain.PharmacyAggregate;

namespace PharmacyCleanArchitecture.Application.Pharmacies.Commands.Create;

public class CreatePharmacyCommandHandler(
    IPharmacyDbContext dbContext,
    IValidator<CreatePharmacyCommand> validator
) : IRequestHandler<CreatePharmacyCommand, ErrorOr<Pharmacy>>
{
    public async Task<ErrorOr<Pharmacy>> Handle(CreatePharmacyCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.Errors.ConvertAll(validationFailure =>
                Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));
        }

        ErrorOr<Address> addressCreationResult = Address.Create(request.Street, request.City, request.PostalCode, request.CountryIsoCode);
        if (addressCreationResult.IsError) return addressCreationResult.Errors;

        ErrorOr<Pharmacy> pharmacyCreationResult = Pharmacy.Create(
            id: Guid.NewGuid(),
            name: request.Name,
            address: addressCreationResult.Value
        );
        if (pharmacyCreationResult.IsError) return pharmacyCreationResult.Errors;

        await dbContext.Pharmacies.AddAsync(pharmacyCreationResult.Value, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return pharmacyCreationResult.Value;
    }
}