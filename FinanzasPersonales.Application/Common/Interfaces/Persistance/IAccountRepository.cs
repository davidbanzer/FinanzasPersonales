using FinanzasPersonales.Domain.AccountAggregate;

namespace FinanzasPersonales.Application.Common.Interfaces.Persistance;

public interface IAccountRepository
{
    void Add(Account account);
    
    List<Account>? GetAccountsByUserId(Guid userId);

    Account? GetAccountById(Guid id);

    void Update(Account account);

    void Delete(Account account);

    decimal GetBalanceByAccountId(Guid accountId);

    decimal GetBalanceByUserId(Guid userId);
}