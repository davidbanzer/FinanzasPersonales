using FinanzasPersonales.Application.Authentication.Commands.Register;
using FinanzasPersonales.Application.Authentication.Common;
using FinanzasPersonales.Application.Authentication.Queries.Login;
using FinanzasPersonales.Contracts.Authentication;
using Mapster;

namespace FinanzasPersonales.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        .Map(dest => dest, src => src.User);
    }
}