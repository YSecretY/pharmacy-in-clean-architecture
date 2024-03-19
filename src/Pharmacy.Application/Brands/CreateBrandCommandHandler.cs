using MediatR;
using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using Pharmacy.Application.Interfaces.Persistence;
using Pharmacy.Domain.Brand;

namespace Pharmacy.Application.Brands;

public class CreateBrandCommandHandler(
        IBrandRepository brandRepository,
        IValidator<CreateBrandCommand> validator)
    : IRequestHandler<CreateBrandCommand, ErrorOr<Brand>>
{
    private readonly IBrandRepository _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
    private readonly IValidator<CreateBrandCommand> _validator = validator ?? throw new ArgumentNullException(nameof(validator));


    public async Task<ErrorOr<Brand>> Handle(CreateBrandCommand command, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.Errors.ConvertAll(validationFailure =>
                Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));
        }

        ErrorOr<Brand> brandCreationResult = Brand.Create(Guid.NewGuid(), command.Name, command.ImageLogoUrl);
        if (brandCreationResult.IsError) return brandCreationResult.Errors;

        return await _brandRepository.AddAsync(brandCreationResult.Value, cancellationToken);
    }
}