using ErrorOr;
using MediatR;
using PharmacyCleanArchitecture.Domain.Products;

namespace PharmacyCleanArchitecture.Application.Products.Queries.GetById;

public record GetProductByIdQuery(Guid Id) : IRequest<ErrorOr<Product>>;