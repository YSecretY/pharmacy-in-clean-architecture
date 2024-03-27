using ErrorOr;
using MediatR;
using Pharmacy.Domain.Categories;

namespace Pharmacy.Application.Categories.Commands.Create;

public record CreateCategoryCommand(string Name, string? ImageUrl) : IRequest<ErrorOr<Category>>;