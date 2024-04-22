using ErrorOr;
using MediatR;

namespace PharmacyCleanArchitecture.Application.Products.Commands.Remove;

public record RemoveProductByIdCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;