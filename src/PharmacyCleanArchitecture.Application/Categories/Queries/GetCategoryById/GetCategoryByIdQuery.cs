using ErrorOr;
using MediatR;
using PharmacyCleanArchitecture.Domain.Categories;

namespace PharmacyCleanArchitecture.Application.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(Guid Guid) : IRequest<ErrorOr<Category>>;