using Mapster;
using Pharmacy.Application.Users.EmailConfirmation;
using Pharmacy.Application.Users.Login;
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
    }
}