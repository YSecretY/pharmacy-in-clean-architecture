using MediatR;
using ErrorOr;
using Pharmacy.Domain.Product;

namespace Pharmacy.Application.Products.Get;

public record GetProductCommand(Guid Id) : IRequest<ErrorOr<Product>>;