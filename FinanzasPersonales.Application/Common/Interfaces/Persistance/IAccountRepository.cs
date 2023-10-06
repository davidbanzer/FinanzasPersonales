using FinanzasPersonales.Domain.Account;

namespace FinanzasPersonales.Application.Common.Interfaces.Persistance;

public interface IAccountRepository
{
    void Add(Account account);

    List<Account>? GetAccountsByUserId(Guid userId);
}