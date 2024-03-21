using ErrorOr;
using MediatR;
using Pharmacy.Domain.Category;

namespace Pharmacy.Application.Categories.Commands.Queries.GetCategoryById;

public record GetCategoryByIdQuery(Guid Guid) : IRequest<ErrorOr<Category>>;