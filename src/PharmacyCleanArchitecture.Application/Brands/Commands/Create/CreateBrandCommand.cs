using ErrorOr;
using MediatR;
using PharmacyCleanArchitecture.Domain.Brands;

namespace PharmacyCleanArchitecture.Application.Brands.Commands.Create;

public record CreateBrandCommand(string Name, string? ImageLogoUrl) : IRequest<ErrorOr<Brand>>;