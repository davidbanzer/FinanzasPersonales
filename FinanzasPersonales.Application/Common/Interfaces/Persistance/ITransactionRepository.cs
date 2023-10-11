
using FinanzasPersonales.Domain.TransactionAggregate;

namespace FinanzasPersonales.Application.Common.Interfaces.Persistance;

public interface ITransactionRepository
{
    void Add(Transaction transaction);

    Transaction? GetTransactionById(Guid id);

    List<Transaction>? GetTransactionsByAccountId(Guid accountId);

    void Update(Transaction transaction);

    void Delete(Transaction transaction);
}