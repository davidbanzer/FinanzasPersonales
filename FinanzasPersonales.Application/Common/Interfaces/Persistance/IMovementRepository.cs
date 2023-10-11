using FinanzasPersonales.Domain.MovemenAggregate;

namespace FinanzasPersonales.Application.Common.Interfaces.Persistance;

public interface IMovementRepository 
{
    void Add(Movement movement);

    Movement? GetMovementById(Guid id);

    List<Movement>? GetMovementsByAccountId(Guid accountId);

    List<Movement>? GetMovementsByUserId(Guid userId);

    void Update(Movement movement);

    void Delete(Movement movement);
}