using FinanzasPersonales.Application.Authentication.Queries.GetUserById;
using FinanzasPersonales.Contracts.Authentication;
using FinanzasPersonales.Domain.UserAggregate;
using Mapster;

namespace FinanzasPersonales.Api.Common.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        config.NewConfig<User, UserResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.Email, src => src.Email);

        config.NewConfig<Guid, GetUserByIdQuery>()
            .Map(dest => dest.UserId, src => src);
    }
}