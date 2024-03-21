using ErrorOr;
using MediatR;

namespace Pharmacy.Application.Categories.Commands.Remove;

public record RemoveCategoryByIdCommand(Guid Guid) : IRequest<ErrorOr<Deleted>>;