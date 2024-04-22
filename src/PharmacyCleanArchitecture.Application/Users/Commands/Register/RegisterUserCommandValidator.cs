using FluentValidation;

namespace PharmacyCleanArchitecture.Application.Users.Commands.Register;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(u => u.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(255);

        RuleFor(u => u.FirstName)
            .MaximumLength(100);

        RuleFor(u => u.PhoneNumber)
            .MaximumLength(13)
            .Matches("^[0-9]*$")
            .When(u => !string.IsNullOrEmpty(u.PhoneNumber));

        RuleFor(u => u.Password)
            .NotNull()
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(500)
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$")
            .WithMessage("Password must contain at least one lowercase letter, one uppercase letter and 8 symbols length.");
    }
};