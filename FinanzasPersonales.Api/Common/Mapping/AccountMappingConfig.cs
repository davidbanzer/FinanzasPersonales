using FinanzasPersonales.Application.Accounts.Commands.CreateAccount;
using FinanzasPersonales.Application.Accounts.Commands.DeleteAccount;
using FinanzasPersonales.Application.Accounts.Commands.UpdateAccount;
using FinanzasPersonales.Application.Accounts.Common;
using FinanzasPersonales.Application.Accounts.Queries.GetAccountsByUserId;
using FinanzasPersonales.Contracts.Accounts;
using Mapster;

namespace FinanzasPersonales.Api.Common.Mapping;

public class AccountMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Create
        config.NewConfig<(CreateAccountRequest Request, Guid UserId), CreateAccountCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<AccountResult, AccountResponse>()
            .Map(dest => dest.Id, src => src.Account.Id.Value)
            .Map(dest => dest.Name, src => src.Account.Name)
            .Map(dest => dest.Description, src => src.Account.Description)
            .Map(dest => dest.InitialBalance, src => src.Account.InitialBalance.Value)
            .Map(dest => dest.UserId, src => src.Account.UserId.Value);

        // Get By UserId
        config.NewConfig<Guid, GetAccountsByUserIdQuery>()
            .Map(dest => dest.UserId, src => src);

        config.NewConfig<List<AccountResult>, List<AccountResponse>>()
            .Map(dest => dest , src => src);

        // Update
        config.NewConfig<(UpdateAccountRequest Request, Guid AccountId), UpdateAccountCommand>()
            .Map(dest => dest.Id, src => src.AccountId)
            .Map(dest => dest, src => src.Request);

        // Delete
        config.NewConfig<Guid, DeleteAccountCommand>()
            .Map(dest => dest.Id, src => src);

    }
}