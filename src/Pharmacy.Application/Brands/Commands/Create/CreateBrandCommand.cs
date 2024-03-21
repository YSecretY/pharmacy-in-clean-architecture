using ErrorOr;
using MediatR;
using Pharmacy.Domain.Brand;

namespace Pharmacy.Application.Brands.Commands.Create;

public record CreateBrandCommand(string Name, string? ImageLogoUrl) : IRequest<ErrorOr<Brand>>;