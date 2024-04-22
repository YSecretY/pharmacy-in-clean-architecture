using ErrorOr;
using MediatR;

namespace PharmacyCleanArchitecture.Application.Brands.Commands.Remove;

public record RemoveBrandByIdCommand(Guid Guid) : IRequest<ErrorOr<Deleted>>;