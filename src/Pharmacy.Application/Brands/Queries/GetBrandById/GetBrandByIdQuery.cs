using ErrorOr;
using MediatR;
using Pharmacy.Domain.Brand;

namespace Pharmacy.Application.Brands.Queries.GetBrandById;

public record GetBrandByIdQuery(Guid Guid) : IRequest<ErrorOr<Brand>>;