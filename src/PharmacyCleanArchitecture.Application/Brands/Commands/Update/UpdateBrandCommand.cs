using ErrorOr;
using MediatR;
using PharmacyCleanArchitecture.Domain.Brands;

namespace PharmacyCleanArchitecture.Application.Brands.Commands.Update;

public record UpdateBrandCommand(Guid Guid, string Name, string? LogoImageUrl) : IRequest<ErrorOr<Brand>>;