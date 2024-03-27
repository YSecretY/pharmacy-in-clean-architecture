using ErrorOr;
using MediatR;
using Pharmacy.Domain.Brands;

namespace Pharmacy.Application.Brands.Queries.GetBrandById;

public record GetBrandByIdQuery(Guid Guid) : IRequest<ErrorOr<Brand>>;