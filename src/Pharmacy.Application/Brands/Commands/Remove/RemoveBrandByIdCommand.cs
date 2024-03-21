using ErrorOr;
using MediatR;

namespace Pharmacy.Application.Brands.Commands.Remove;

public record RemoveBrandByIdCommand(Guid Guid) : IRequest<ErrorOr<Deleted>>;