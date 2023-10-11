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

    public List<Transaction>? GetTransactionsByAccountId(Guid accountId)
    {
        return _dbContext.Transactions
        .AsEnumerable()
        .Where(t => t.OriginAccountId.Value == accountId || t.DestinationAccountId.Value == accountId)
        .ToList();
    }

    public void Update(Transaction transaction)
    {
        _dbContext.Transactions.Update(transaction);
        _dbContext.SaveChanges();
    }
}