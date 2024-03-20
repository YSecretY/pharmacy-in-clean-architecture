using MediatR;
using ErrorOr;
using Pharmacy.Domain.Brand;

namespace Pharmacy.Application.Brands.Commands.UpdateBrand;

public record UpdateBrandCommand(Guid Guid, string Name, string? LogoImageUrl) : IRequest<ErrorOr<Brand>>;