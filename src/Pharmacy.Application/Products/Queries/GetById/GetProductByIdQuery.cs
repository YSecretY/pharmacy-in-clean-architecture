using ErrorOr;
using MediatR;
using Pharmacy.Domain.Products;

namespace Pharmacy.Application.Products.Queries.GetById;

public record GetProductByIdQuery(Guid Id) : IRequest<ErrorOr<Product>>;