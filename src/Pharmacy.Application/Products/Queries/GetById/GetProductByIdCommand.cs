using ErrorOr;
using MediatR;
using Pharmacy.Domain.Product;

namespace Pharmacy.Application.Products.Queries.GetById;

public record GetProductByIdCommand(Guid Id) : IRequest<ErrorOr<Product>>;