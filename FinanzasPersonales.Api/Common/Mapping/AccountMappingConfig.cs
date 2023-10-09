using FinanzasPersonales.Application.Accounts.Commands.CreateAccount;
using FinanzasPersonales.Application.Accounts.Queries.GetAccountsByUserId;
using FinanzasPersonales.Contracts.Accounts;
using FinanzasPersonales.Domain.AccountAggregate;
using Mapster;

namespace FinanzasPersonales.Api.Common.Mapping;

public class AccountMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateAccountRequest Request, Guid UserId), CreateAccountCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Account, AccountResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.InitialBalance, src => src.InitialBalance.Value)
            .Map(dest => dest.UserId, src => src.UserId.Value);

        config.NewConfig<Guid, GetAccountsByUserIdQuery>()
            .Map(dest => dest.UserId, src => src);

        config.NewConfig<List<Account>, List<AccountResponse>>()
            .Map(dest => dest, src => src);

    }
}