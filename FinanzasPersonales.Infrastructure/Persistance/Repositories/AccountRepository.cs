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

    public Account? GetAccountById(Guid id)
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

    public decimal GetBalanceByAccountId(Guid accountId)
    {
        // Obtener la cuenta, luego obtener todos los movimientos de esa cuenta y sumarlos o restarlos si su type es Ingreso o Egreso
        var account = _dbContext.Accounts
        .AsEnumerable()
        .SingleOrDefault(a => a.Id.Value == accountId);

        if (account == null)
        {
            throw new Exception("La cuenta no existe");
        }

        var movements = _dbContext.Movements
        .AsEnumerable()
        .Where(m => m.AccountId.Value == accountId);

        if (movements.Count() == 0)
        {
            return account.InitialBalance.Value;
        }

        decimal balance = 0;
        balance += account.InitialBalance.Value;

        foreach (var movement in movements)
        {
            if (movement.Type == "Ingreso")
            {
                balance += movement.Amount.Value;
            }
            else
            {
                balance -= movement.Amount.Value;
            }
        }

        return balance;
    }

    public decimal GetBalanceByUserId(Guid userId)
    {
        // obtener todas las cuentas del usuario, luego obtener todos los movimientos de esas cuentas y sumarlos o restarlos si su type es Ingreso o Egreso
        var accounts = _dbContext.Accounts
        .AsEnumerable()
        .Where(a => a.UserId.Value == userId);

        var movements = _dbContext.Movements
        .AsEnumerable()
        .Where(m => accounts.Any(a => a.Id.Value == m.AccountId.Value));

        if (movements.Count() == 0)
        {
            return accounts.Sum(a => a.InitialBalance.Value);
        }

        decimal balance = 0;
        decimal initialBalance = 0;

        foreach (var movement in movements)
        {
            var account = accounts.SingleOrDefault(a => a.Id.Value == movement.AccountId.Value);

            initialBalance += account!.InitialBalance.Value;
            if (movement.Type == "Ingreso")
            {
                balance += movement.Amount.Value;
            }
            else
            {
                balance -= movement.Amount.Value;
            }

        }

        return balance;
    }
}