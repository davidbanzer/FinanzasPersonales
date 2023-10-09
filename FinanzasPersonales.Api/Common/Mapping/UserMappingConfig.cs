using FinanzasPersonales.Application.Authentication.Queries.GetUserById;
using FinanzasPersonales.Application.Users.Common;
using FinanzasPersonales.Contracts.Authentication;
using FinanzasPersonales.Domain.UserAggregate;
using Mapster;

namespace FinanzasPersonales.Api.Common.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        config.NewConfig<UserResult, UserResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value)
            .Map(dest => dest.FirstName, src => src.User.FirstName)
            .Map(dest => dest.LastName, src => src.User.LastName)
            .Map(dest => dest.Email, src => src.User.Email);

        config.NewConfig<Guid, GetUserByIdQuery>()
            .Map(dest => dest.UserId, src => src);
    }
}