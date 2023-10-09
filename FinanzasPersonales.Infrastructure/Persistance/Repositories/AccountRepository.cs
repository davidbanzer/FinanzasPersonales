using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.AccountAggregate;

namespace FinanzasPersonales.Infrastructure.Persistance;

public class AccountRepository : IAccountRepository
{

    private readonly FinanzasPersonalesDbContext _dbContext;

    public AccountRepository(FinanzasPersonalesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Account account)
    {
        _dbContext.Add(account);
        _dbContext.SaveChanges();
    }

    public List<Account>? GetAccountsByUserId(Guid userId)
    {
        return _dbContext.Accounts
        .AsEnumerable() // Cargar todos los registros en memoria
        .Where(a => a.UserId.Value == userId)
        .ToList();
    }
}