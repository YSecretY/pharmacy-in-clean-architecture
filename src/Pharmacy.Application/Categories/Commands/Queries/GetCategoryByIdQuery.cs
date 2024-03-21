using MediatR;
using ErrorOr;
using Pharmacy.Domain.Category;

namespace Pharmacy.Application.Categories.Commands.Queries;

public record GetCategoryByIdQuery(Guid Guid) : IRequest<ErrorOr<Category>>;