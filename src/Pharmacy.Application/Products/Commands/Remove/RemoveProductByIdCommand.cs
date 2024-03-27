using ErrorOr;
using MediatR;

namespace Pharmacy.Application.Products.Commands.Remove;

public record RemoveProductByIdCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;