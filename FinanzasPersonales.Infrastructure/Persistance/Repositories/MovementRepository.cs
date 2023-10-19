using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.MovementAggregate;

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

    public List<Movement>? GetMovementsByCategoryId(Guid categoryId)
    {
        return _dbContext.Movements
        .AsEnumerable()
        .Where(m => m.CategoryId.Value == categoryId)
        .ToList();
    }

    public List<Movement>? GetMovementsByDate(string month, Guid userId)
    {
        var accounts = _dbContext.Accounts
            .AsEnumerable()
            .Where(a => a.UserId.Value == userId)
            .ToList();
    
        var movements = _dbContext.Movements
            .AsEnumerable()
            .Where(m => accounts.Any(a => a.Id.Value == m.AccountId.Value))
            .Where(m => m.CreatedDate.ToString("MM/yyyy") == month)
            .ToList();

        return movements;
    }

    public List<Movement>? GetMovementsByUserId(Guid userId)
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

        return movements;
    }

    public void Update(Movement movement)
    {
        _dbContext.Movements.Update(movement);
        _dbContext.SaveChanges();
    }
}