using Mapster;
using Pharmacy.Application.Users.ChangeEmail;
using Pharmacy.Application.Users.ChangePassword;
using Pharmacy.Application.Users.EmailConfirmation;
using Pharmacy.Application.Users.Login;
using Pharmacy.Application.Users.MakeAdmin;
using Pharmacy.Application.Users.Register;
using Pharmacy.Contracts.Users;

namespace Pharmacy.Api.Common.Mapping;

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
    }
}