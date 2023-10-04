using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.Account;

namespace FinanzasPersonales.Infrastructure.Persistance;

public class AccountRepository: IAccountRepository
{
    private static readonly List<Account> _accounts = new();
    public void Add(Account account)
    {
        _accounts.Add(account);
    }
}