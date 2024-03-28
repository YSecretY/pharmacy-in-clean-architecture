using ErrorOr;
using MediatR;
using PharmacyCleanArchitecture.Domain.Categories;

namespace PharmacyCleanArchitecture.Application.Categories.Commands.Update;

public record UpdateCategoryCommand(Guid Guid, string Name, string? ImageUrl) : IRequest<ErrorOr<Category>>;