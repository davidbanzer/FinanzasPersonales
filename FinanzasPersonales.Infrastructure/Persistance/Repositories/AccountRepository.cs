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

    public void Delete(Account account)
    {
        _dbContext.Remove(account);
        _dbContext.SaveChanges();
    }

    public List<Account>? GetAccountsByUserId(Guid userId)
    {
        return _dbContext.Accounts
        .AsEnumerable()
        .Where(a => a.UserId.Value == userId)
        .ToList();
    }

    public Account? GetById(Guid id)
    {
        return _dbContext.Accounts
        .AsEnumerable() 
        .SingleOrDefault(u => u.Id.Value == id);
    }

    public void Update(Account account)
    {
        _dbContext.Update(account);
        _dbContext.SaveChanges();
    }
}