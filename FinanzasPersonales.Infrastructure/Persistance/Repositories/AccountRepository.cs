using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.Account;

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
}