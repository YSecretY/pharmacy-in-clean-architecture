using ErrorOr;
using MediatR;
using PharmacyCleanArchitecture.Domain.Categories;

namespace PharmacyCleanArchitecture.Application.Categories.Commands.Create;

public record CreateCategoryCommand(string Name, string? ImageUrl) : IRequest<ErrorOr<Category>>;