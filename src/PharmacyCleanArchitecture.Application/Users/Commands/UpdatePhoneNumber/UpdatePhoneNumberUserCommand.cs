using ErrorOr;
using MediatR;

namespace PharmacyCleanArchitecture.Application.Users.Commands.UpdatePhoneNumber;

public record UpdatePhoneNumberUserCommand(string PhoneNumber) : IRequest<ErrorOr<Updated>>;