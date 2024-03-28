using ErrorOr;
using MediatR;

namespace PharmacyCleanArchitecture.Application.Categories.Commands.Remove;

public record RemoveCategoryByIdCommand(Guid Guid) : IRequest<ErrorOr<Deleted>>;