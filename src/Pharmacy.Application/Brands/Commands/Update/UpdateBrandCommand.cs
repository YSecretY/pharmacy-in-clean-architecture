using ErrorOr;
using MediatR;
using Pharmacy.Domain.Brand;

namespace Pharmacy.Application.Brands.Commands.Update;

public record UpdateBrandCommand(Guid Guid, string Name, string? LogoImageUrl) : IRequest<ErrorOr<Brand>>;