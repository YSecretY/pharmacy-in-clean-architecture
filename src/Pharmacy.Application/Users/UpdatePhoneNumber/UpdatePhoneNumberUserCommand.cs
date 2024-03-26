using ErrorOr;
using MediatR;

namespace Pharmacy.Application.Users.UpdatePhoneNumber;

public record UpdatePhoneNumberUserCommand(string PhoneNumber) : IRequest<ErrorOr<Updated>>;