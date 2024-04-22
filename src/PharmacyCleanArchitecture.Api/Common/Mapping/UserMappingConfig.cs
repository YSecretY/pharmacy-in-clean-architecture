using Mapster;
using PharmacyCleanArchitecture.Application.Users.Commands.ChangeEmail;
using PharmacyCleanArchitecture.Application.Users.Commands.ChangePassword;
using PharmacyCleanArchitecture.Application.Users.Commands.EmailConfirmation;
using PharmacyCleanArchitecture.Application.Users.Commands.Login;
using PharmacyCleanArchitecture.Application.Users.Commands.MakeAdmin;
using PharmacyCleanArchitecture.Application.Users.Commands.Register;
using PharmacyCleanArchitecture.Application.Users.Commands.UpdatePhoneNumber;
using PharmacyCleanArchitecture.Contracts.Users;

namespace PharmacyCleanArchitecture.Api.Common.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterUserRequest, RegisterUserCommand>()
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Password, src => src.Password)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber);

        config.NewConfig<LoginUserRequest, LoginUserCommand>()
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Password, src => src.Password);

        config.NewConfig<ConfirmEmailRequest, ConfirmEmailCommand>()
            .Map(dest => dest.UserEmail, src => src.UserEmail)
            .Map(dest => dest.EmailConfirmationToken, src => src.EmailConfirmationToken);

        config.NewConfig<ChangeUserPasswordRequest, ChangePasswordCommand>()
            .Map(dest => dest.OldPassword, src => src.OldPassword)
            .Map(dest => dest.NewPassword, src => src.NewPassword)
            .Map(dest => dest.NewPasswordConfirmation, src => src.NewPasswordConfirmation);

        config.NewConfig<ChangeEmailRequest, ChangeEmailCommand>()
            .Map(dest => dest.OldEmail, src => src.OldEmail)
            .Map(dest => dest.NewEmail, src => src.NewEmail)
            .Map(dest => dest.ConfirmationToken, src => src.ConfirmationToken);

        config.NewConfig<SendEmailChangeConfirmationRequest, SendEmailChangeConfirmationCommand>()
            .Map(dest => dest.ReceiverEmail, src => src.ReceiverEmail);

        config.NewConfig<MakeAdminUserRequest, MakeAdminUserCommand>()
            .Map(dest => dest.UserId, src => src.UserId);

        config.NewConfig<UpdatePhoneNumberUserRequest, UpdatePhoneNumberUserCommand>()
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber);
    }
}