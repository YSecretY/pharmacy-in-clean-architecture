using ErrorOr;
using MediatR;
using PharmacyCleanArchitecture.Domain.Brands;

namespace PharmacyCleanArchitecture.Application.Brands.Queries.GetBrandById;

public record GetBrandByIdQuery(Guid Guid) : IRequest<ErrorOr<Brand>>;