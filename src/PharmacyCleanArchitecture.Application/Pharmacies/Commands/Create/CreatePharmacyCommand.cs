using ErrorOr;
using MediatR;

namespace PharmacyCleanArchitecture.Application.Pharmacies.Commands.Create;

public record CreatePharmacyCommand
    (string Name, string CountryIsoCode, string City, string PostalCode, string Street) : IRequest<ErrorOr<Domain.PharmacyAggregate.Pharmacy>>;