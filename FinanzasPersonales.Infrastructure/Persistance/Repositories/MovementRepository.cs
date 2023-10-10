using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.MovemenAggregate;

namespace FinanzasPersonales.Infrastructure.Persistance.Repositories;

public class MovementRepository : IMovementRepository
{
    private readonly FinanzasPersonalesDbContext _dbContext;

    public MovementRepository(FinanzasPersonalesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Movement movement)
    {
        _dbContext.Movements.Add(movement);
        _dbContext.SaveChanges();
    }

    public void Delete(Movement movement)
    {
        _dbContext.Movements.Remove(movement);
        _dbContext.SaveChanges();
    }

    public Movement? GetMovementById(Guid id)
    {
        return _dbContext.Movements
        .AsEnumerable()
        .FirstOrDefault(m => m.Id.Value == id);
    }

    public List<Movement>? GetMovementsByAccountId(Guid accountId)
    {
        return _dbContext.Movements
        .AsEnumerable()
        .Where(m => m.AccountId.Value == accountId)
        .ToList();
    }

    public void Update(Movement movement)
    {
        _dbContext.Movements.Update(movement);
        _dbContext.SaveChanges();
    }
}