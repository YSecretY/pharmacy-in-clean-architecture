using ErrorOr;
using MediatR;

namespace Pharmacy.Application.Brands.Commands.RemoveBrand;

public record RemoveBrandByIdCommand(Guid Guid) : IRequest<ErrorOr<Success>>;