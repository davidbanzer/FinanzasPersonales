using FinanzasPersonales.Domain.AccountAggregate;

namespace FinanzasPersonales.Application.Common.Interfaces.Persistance;

public interface IAccountRepository
{
    void Add(Account account);

    List<Account>? GetAccountsByUserId(Guid userId);
}