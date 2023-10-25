using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.TransferAggregate;

namespace FinanzasPersonales.Infrastructure.Persistance.Repositories;

public class TransferRepository : ITransferRepository
{
    private readonly FinanzasPersonalesDbContext _dbContext;

    public TransferRepository(FinanzasPersonalesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Transfer Transfer)
    {
        _dbContext.Transfers.Add(Transfer);
        _dbContext.SaveChanges();
    }

    public void Delete(Transfer Transfer)
    {
        _dbContext.Transfers.Remove(Transfer);
        _dbContext.SaveChanges();
    }

    public Transfer? GetTransferById(Guid id)
    {
        return _dbContext.Transfers
        .AsEnumerable()
        .FirstOrDefault(t => t.Id.Value == id);
    }

    public List<Transfer>? GetTransfersByMovementId(Guid movementId)
    {
        var transfers = _dbContext.Transfers
            .AsEnumerable()
            .Where(t => t.OriginMovementId.Value == movementId || t.DestinationMovementId.Value == movementId)
            .ToList();

        return transfers;
    }

    public List<Transfer>? GetTransfersByUserId(Guid userId)
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
        var Transfers = _dbContext.Transfers
            .AsEnumerable()
            .Where(t => movements.Any(m => m.Id.Value == t.OriginMovementId.Value || m.Id.Value == t.DestinationMovementId.Value))
            .ToList();

        return Transfers;
    }

    public void Update(Transfer Transfer)
    {
        _dbContext.Transfers.Update(Transfer);
        _dbContext.SaveChanges();
    }
}