using ErrorOr;
using MediatR;
using Pharmacy.Domain.Category;

namespace Pharmacy.Application.Categories.Commands.Create;

public record CreateCategoryCommand(string Name, string? ImageUrl) : IRequest<ErrorOr<Category>>;