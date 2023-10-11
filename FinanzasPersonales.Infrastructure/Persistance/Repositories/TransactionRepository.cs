using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.TransactionAggregate;

namespace FinanzasPersonales.Infrastructure.Persistance.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly FinanzasPersonalesDbContext _dbContext;

    public TransactionRepository(FinanzasPersonalesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Transaction transaction)
    {
        _dbContext.Transactions.Add(transaction);
        _dbContext.SaveChanges();
    }

    public void Delete(Transaction transaction)
    {
        _dbContext.Transactions.Remove(transaction);
        _dbContext.SaveChanges();
    }

    public Transaction? GetTransactionById(Guid id)
    {
        return _dbContext.Transactions
        .AsEnumerable()
        .FirstOrDefault(t => t.Id.Value == id);
    }

    public List<Transaction>? GetTransactionsByUserId(Guid userId)
    {
        // Obtener las cuentas del usuario
        var accounts = _dbContext.Accounts
            .AsEnumerable()
            .Where(a => a.UserId.Value == userId)
            .ToList();

        // Obtener los movimientos de las cuentas del usuario
        var movements = _dbContext.Movements
            .AsEnumerable()
            .Where(m => accounts.Any(a => a.Id.Value == m.AccountId.Value))
            .ToList();

        // Obtener las transacciones de los movimientos del usuario
        var transactions = _dbContext.Transactions
            .AsEnumerable()
            .Where(t => movements.Any(m => m.Id.Value == t.OriginMovementId.Value || m.Id.Value == t.DestinationMovementId.Value))
            .ToList();

        return transactions;
    }

    public void Update(Transaction transaction)
    {
        _dbContext.Transactions.Update(transaction);
        _dbContext.SaveChanges();
    }
}