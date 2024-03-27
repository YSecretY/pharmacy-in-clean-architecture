using ErrorOr;
using MediatR;
using Pharmacy.Domain.Categories;

namespace Pharmacy.Application.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(Guid Guid) : IRequest<ErrorOr<Category>>;