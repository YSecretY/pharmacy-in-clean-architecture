using MediatR;
using ErrorOr;
using Pharmacy.Domain.Brand;

namespace Pharmacy.Application.Brands;

public record CreateBrandCommand(string Name, string? ImageLogoUrl) : IRequest<ErrorOr<Brand>>;