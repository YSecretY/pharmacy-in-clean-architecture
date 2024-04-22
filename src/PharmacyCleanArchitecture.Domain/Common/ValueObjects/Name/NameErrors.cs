using ErrorOr;

namespace PharmacyCleanArchitecture.Domain.Common.ValueObjects.Name;

public static class NameErrors
{
    private const int MaxLength = 100;

    public static readonly Error CannotBeNullOrEmpty =
        Error.Validation(code: "Name.CannotBeNullOrEmpty", "Name field cannot be null or empty.");

    public static readonly Error CannotBeTooLong = Error.Validation(code: "Name.TooLong", $"Name cannot be longer than {MaxLength}");
}