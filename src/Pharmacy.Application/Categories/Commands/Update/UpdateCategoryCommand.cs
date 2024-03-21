using MediatR;
using ErrorOr;
using Pharmacy.Domain.Category;

namespace Pharmacy.Application.Categories.Commands.Update;

public record UpdateCategoryCommand(Guid Guid, string Name, string? ImageUrl) : IRequest<ErrorOr<Category>>;