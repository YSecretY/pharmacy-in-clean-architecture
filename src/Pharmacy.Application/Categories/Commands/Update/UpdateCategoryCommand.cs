using MediatR;
using ErrorOr;
using Pharmacy.Domain.Categories;

namespace Pharmacy.Application.Categories.Commands.Update;

public record UpdateCategoryCommand(Guid Guid, string Name, string? ImageUrl) : IRequest<ErrorOr<Category>>;