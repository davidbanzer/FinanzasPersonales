using FinanzasPersonales.Application.Authentication.Commands.Register;
using FinanzasPersonales.Application.Authentication.Common;
using FinanzasPersonales.Application.Authentication.Queries.GetUserById;
using FinanzasPersonales.Application.Authentication.Queries.Login;
using FinanzasPersonales.Contracts.Authentication;
using FinanzasPersonales.Domain.User;
using Mapster;

namespace FinanzasPersonales.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        .Map(dest => dest.Token, src => src.Token)
        .Map(dest => dest.Id, src => src.User.Id.Value)
        .Map(dest => dest.FirstName, src => src.User.FirstName)
        .Map(dest => dest.LastName, src => src.User.LastName)
        .Map(dest => dest.Email, src => src.User.Email);

        config.NewConfig<User, UserResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.Email, src => src.Email);

        config.NewConfig<Guid, GetUserByIdQuery>()
        .Map(dest => dest.UserId, src => src);
    }
}