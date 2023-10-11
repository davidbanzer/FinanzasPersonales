
using FinanzasPersonales.Domain.TransactionAggregate;

namespace FinanzasPersonales.Application.Common.Interfaces.Persistance;

public interface ITransactionRepository
{
    void Add(Transaction transaction);

    Transaction? GetTransactionById(Guid id);

    List<Transaction>? GetTransactionsByUserId(Guid userId);

    void Update(Transaction transaction);

    void Delete(Transaction transaction);
}